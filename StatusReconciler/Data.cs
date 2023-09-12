using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using APITest.DataTransferService;
using APITest.LogOnSrvc;
using APITest.SurveyDataSrvc;
using MPR.Crypto;
using DatabaseType = APITest.DataTransferService.DatabaseType;
using DataLevel = APITest.DataTransferService.DataLevel;
using ErrorMessage = APITest.DataTransferService.ErrorMessage;
using RespondentConfirmitDataResult = APITest.DataTransferService.RespondentConfirmitDataResult;
using RespondentToken = APITest.DataTransferService.RespondentToken;
using ResponseToken = APITest.DataTransferService.ResponseToken;

namespace APITest
{
    public class Data
    {
        public const string KEYCOLUMN_DEFAULT = "MPRID";
        private static string _SecToken = string.Empty;

        public static string Encrypt(string textToEncrypt)
        {
            return Crypto.Encrypt(textToEncrypt);
        }

        public static string Decrypt(string textToDecrypt)
        {
            return Crypto.Decrypt(textToDecrypt);
        }

        public static DataSet GetForProject(string APIUser, string APIPwd, string ConfirmitProjectID,
            List<string> fieldList, string filter)
        {
            return GetForProject(APIUser, APIPwd, true, ConfirmitProjectID, fieldList, filter);
        }

        public static DataSet GetForProject(string APIUser, string APIPwd, bool GetSurveyResponseData,
            string ConfirmitProjectID, List<string> fieldList, string filter)
        {
            var SecToken = DoLogin(APIUser, APIPwd);

            Debug.WriteLine("Pulling data...");

            //get variable collection
            var tvc = new TransferVariableCollection {VariableNames = fieldList.ToArray()};

            if (filter == null)
                filter = string.Empty;

            DataSet ds = null;

            if (GetSurveyResponseData)
            {
                var sdtd = new SurveyDataTransferDef
                {
                    ProjectId = ConfirmitProjectID,
                    DbType = DatabaseType.Production,
                    FilterExpression = filter,
                    VariableCollections = new[] {tvc},
                    IncludeSystemVariables = true
                };

                var dtClient = new DataTransferSoapClient();
                ResponseToken response = null;

                do
                {
                    var result = dtClient.GetData(SecToken, sdtd, response);

                    if (result == null)
                        break;

                    if (ds != null)
                        ds.Merge(result.Result);
                    else
                        ds = result.Result;

                    response = result.ResponseToken;
                } while (!response.LastDataSet);
            }
            else
            {
                var sdtd = new RespondentDataTransferDef
                {
                    ProjectId = ConfirmitProjectID,
                    Expression = filter,
                    FieldNames = fieldList.ToArray()
                };

                var dtClient = new DataTransferSoapClient();
                RespondentToken response = null;

                do
                {
                    var result = dtClient.GetRespondents(SecToken, sdtd, response);

                    if (result == null)
                        break;

                    if (ds != null)
                        ds.Merge(result.Result);
                    else
                        ds = result.Result;

                    response = result.Token;
                } while (!response.LastDataSet);
            }


            return ds;
        }

        public static DataSet GetForProject_CallHistory(string APIUser, string APIPwd, string ConfirmitProjectID,
            List<string> fieldList, string MPRID)
        {
            var SecToken = DoLogin(APIUser, APIPwd);

            Debug.WriteLine("Pulling data...");

            //get variable collection
            //var tvc = new TransferVariableCollection { VariableNames = fieldList.ToArray() };
            var loopID = "callhistoryinfo";
            var tvc = new TransferVariableCollection {VariableNames = fieldList.ToArray(), LoopId = loopID};

            var filter = "MPRID=" + MPRID;

            if (filter == null)
                filter = string.Empty;

            DataSet ds = null;

            var sdtd = new SurveyDataTransferDef
            {
                ProjectId = ConfirmitProjectID,
                DbType = DatabaseType.Production,
                FilterExpression = filter,
                VariableCollections = new[] {tvc},
                IncludeSystemVariables = false
            };

            var dtClient = new DataTransferSoapClient();
            ResponseToken response = null;

            do
            {
                var result = dtClient.GetData(SecToken, sdtd, response);

                if (result == null)
                    break;

                if (ds != null)
                    ds.Merge(result.Result);
                else
                    ds = result.Result;

                response = result.ResponseToken;
            } while (!response.LastDataSet);


            return ds;
        }

        /// <summary>
        ///     Update data in the Confirmit Respondent database using MPRID as the key.
        /// </summary>
        /// <param name="APIUser"></param>
        /// <param name="APIPwd"></param>
        /// <param name="ConfirmitProjectID"></param>
        /// <param name="MPRID"></param>
        /// <param name="dataToUpdate"></param>
        /// <returns></returns>
        public static bool SetDataForCase(string APIUser, string APIPwd, string ConfirmitProjectID, string MPRID,
            Dictionary<string, string> dataToUpdate)
        {
            return SetDataForCase(APIUser, APIPwd, ConfirmitProjectID, false, KEYCOLUMN_DEFAULT, MPRID, dataToUpdate);
        }

        /// <summary>
        ///     Update data in the Confirmit Respondent database using the key provided.
        /// </summary>
        /// <param name="APIUser"></param>
        /// <param name="APIPwd"></param>
        /// <param name="ConfirmitProjectID"></param>
        /// <param name="KeyColumnName">Name of the column to use as the unique key.</param>
        /// <param name="Key">Value for the unique key.</param>
        /// <param name="dataToUpdate"></param>
        /// <param name="GetSurveyResponseData">Set to true for the survey/response data. FALSE for sample/respondent.</param>
        /// <returns></returns>
        public static bool SetDataForCase(string APIUser, string APIPwd, string ConfirmitProjectID,
            bool GetSurveyResponseData, string KeyColumnName, string Key,
            Dictionary<string, string> dataToUpdate)
        {
            //get key to be used with confirmit web-service function
            var key = DoLogin(APIUser, APIPwd);

            //create a table to send to Confirmit to update the data.
            var ds = new DataSet();
            var dt = ds.Tables.Add("respondent"); //Confirmit expects this to be the table name.

            //use the variableNames/Questions to create columns of the table
            var dcs = dataToUpdate.Select(r => new DataColumn(r.Key, typeof(string))).ToArray();
            dt.Columns.AddRange(dcs);

            //populate the row
            var dr = dt.Rows.Add(dataToUpdate.Select(r => r.Value).ToArray());

            //now add the keycolumn, so long as the caller isn't trying to update that column.
            if (!dt.Columns.Contains(KeyColumnName))
            {
                var Keycol = dt.Columns.Add(KeyColumnName, typeof(int));
                dr[Keycol] = Key;
                dt.PrimaryKey = new[] {Keycol};
            }

            var dtClient = new DataTransferSoapClient();

            ErrorMessage[] result;


            if (GetSurveyResponseData)
            {
                dt.TableName = "responseid";
                result = dtClient.UpdateData(key, ConfirmitProjectID, DatabaseType.Production, KeyColumnName, ds, true);
            }
            else
            {
                result = dtClient.UpdateRespondents(key, ConfirmitProjectID, KeyColumnName, ds, true);
            }

            if (result.Length == 0) return true;

            var msg = string.Join(Environment.NewLine,
                result.Select(r => r.ErrorInfoElements.Select(e => e.Description)));

            throw new ApplicationException(msg);
        }


        public static bool SetDataForCaseWithCatiScheduling(string APIUser, string APIPwd, string ConfirmitProjectID,
            string KeyColumnName, string Key,
            Dictionary<string, string> dataToUpdate)
        {
            //get key to be used with confirmit web-service function
            var key = DoLogin(APIUser, APIPwd);

            //create a table to send to Confirmit to update the data.
            var ds = new DataSet();
            var dt = ds.Tables.Add("respondent"); //Confirmit expects this to be the table name.

            //use the variableNames/Questions to create columns of the table
            var dcs = dataToUpdate.Select(r => new DataColumn(r.Key, typeof(string))).ToArray();
            dt.Columns.AddRange(dcs);

            //populate the row
            var dr = dt.Rows.Add(dataToUpdate.Select(r => r.Value).ToArray());

            //now add the keycolumn, so long as the caller isn't trying to update that column.
            if (!dt.Columns.Contains(KeyColumnName))
            {
                //var Keycol = dt.Columns.Add(KeyColumnName, typeof(Int32));
                var Keycol = dt.Columns.Add(KeyColumnName, typeof(string));
                dr[Keycol] = Key;
                dt.PrimaryKey = new[] {Keycol};
            }

            var dtClient = new SurveyDataSoapClient();

            SurveyDataSrvc.ErrorMessage[] result;
            var b1 = false;

            try
            {
                result = dtClient.UpdateExistingRespondentsWithCatiScheduling(key, ConfirmitProjectID, ds, true,
                    KeyColumnName, false, 0, CatiScheduling.Full);
                b1 = result.Length == 0;
            }
            catch (Exception ex)
            {
                Debug.Write("Failed to login.");
                Debug.WriteLine(ex.Message);
            }


            //if (result.Length == 0) return true;
            return b1;

            //var msg = String.Join(Environment.NewLine,
            //    result.Select(r => r.ErrorInfoElements.Select(e => e.Description)));

            //throw new ApplicationException(msg);
        }


        /// <summary>
        ///     Update LOCATING data in the Confirmit Respondent database using the MPRID.
        /// </summary>
        public static bool SetDataForLocatingCase(string APIUser, string APIPwd, string ConfirmitProjectID,
            string MPRID,
            Dictionary<string, string> dataToUpdate)
        {
            try
            {
                //Importand to update Response data first!
                var b1 = true;
                var b2 = true;
                var b3 = true;

                List<string> fieldList = null;
                fieldList = new List<string>(3);
                fieldList.Add("MPRID");
                fieldList.Add("respid");
                fieldList.Add("status");
                var ds = GetForProject(APIUser, APIPwd, true, ConfirmitProjectID, fieldList, "MPRID=" + MPRID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    var status = ds.Tables[0].Rows[0]["status"].ToString();
                    if (status == "complete")
                        return false;
                    var respid = ds.Tables[0].Rows[0]["respid"].ToString();
                    b1 = SetDataForCase(APIUser, APIPwd, ConfirmitProjectID, true, "respid", respid, dataToUpdate);
                }


                //Update Respondent db (WITHOUT CatiScheduling), to resolve known "unique MPRID" issue in Confirmit.
                if (b1) b2 = SetDataForCase(APIUser, APIPwd, ConfirmitProjectID, false, "MPRID", MPRID, dataToUpdate);
                //Update Respondent db again, WITH CatiScheduling
                if (b1 & b2)
                    b3 = SetDataForCaseWithCatiScheduling(APIUser, APIPwd, ConfirmitProjectID, "MPRID", MPRID,
                        dataToUpdate);

                return b1 & b2 & b3;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SendDataByMPRID(string APIUser, string APIPwd, string ConfirmitProjectID, string MPRID,
            Dictionary<string, string> dataToUpdate, Dictionary<string, string> responseDataToUpdate, Dictionary<string, string> schedulingDataToUpdate)
        {

            try
            {
                //Importand to update Response data first!
                bool b1 = true;
                bool b2 = true;
                bool b3 = true;

                List<string> fieldList = null;
                fieldList = new List<string>(3);
                fieldList.Add("MPRID");
                fieldList.Add("respid");
                fieldList.Add("status");

                DataSet ds = GetForProject(APIUser, APIPwd, true, ConfirmitProjectID, fieldList, "MPRID=" + MPRID);

                //Check response db to see whether the case is complete or not, if complete return false
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Commented the code for BHSIS Project Needs on 06/24/2020 BT:
                    //string status = ds.Tables[0].Rows[0]["status"].ToString();
                    //if (status == "complete")
                    //    return false;
                    // Commented the code for BHSIS Project Needs on 06/24/2020 BT:

                    if (responseDataToUpdate.Count > 0)
                    {
                        string respid = ds.Tables[0].Rows[0]["respid"].ToString();

                        b1 = SetDataForCase(APIUser, APIPwd, ConfirmitProjectID, true, "respid", respid, responseDataToUpdate);
                    }

                }
 

                if (b1)
                {
                    b2 = SetDataForCase(APIUser, APIPwd, ConfirmitProjectID, false, "MPRID", MPRID, dataToUpdate);
                }

                if (schedulingDataToUpdate.Count() > 0)
                { 
                    //Update Respondent db again, WITH CatiScheduling
                    if (b1 & b2)
                    {
                        b3 = SetDataForCaseWithCatiScheduling(APIUser, APIPwd, ConfirmitProjectID, "MPRID", MPRID, schedulingDataToUpdate);
                    }
                }
                return b1 & b2 & b3;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new ConfirmItAPIException(MPRID, ConfirmitProjectID, dataToUpdate, responseDataToUpdate, schedulingDataToUpdate, ex);
            }      
        }

   
        public static void TEST_DataTransferRespondentUpload_ORIGINAL(string key, string projectId, string strMPRID)
        {
            // New instance of the SurveyData webservice.
            var dataTransfer = new DataTransferSoapClient();

            RespondentToken token = null;
            RespondentConfirmitDataResult result;
            DataLevel dataLevel;

            // Create a RespondentDataTransferDef object to get an empty list of  respondents
            // from the given project.
            //Expression = "MPRID = " + strMPRID
            var respondentDataTransferDef = new RespondentDataTransferDef
            {
                ProjectId = projectId,
                Expression = "respid=40"
            };

            var fieldNames = new ArrayList();
            fieldNames.Add("CaseCATILive");
            fieldNames.Add("LocType");
            fieldNames.Add("MPRID");
            fieldNames.Add("PhoneList_1");
            respondentDataTransferDef.FieldNames = (string[]) fieldNames.ToArray(typeof(string));


            // Get the respondents. Run in loop while there is more data to get.
            do
            {
                //GetRespondentsGeneral - Gets a ConfirmitData object with data that is populated according to the filter (respondentTransferDef)
                result = dataTransfer.GetRespondentsGeneral(key, respondentDataTransferDef, token);
                token = result.Token;
                dataLevel = result.Result.DataLevels[0];

                //Create a list of column indexes that we want to populate the data for ("email", "CITY", "INDIVIDUAL_ID")
                var columnIndexes = new List<int>();
                var indexedVariables =
                    dataLevel.Variables.Select((variable, i) => new {Variable = variable, Index = i});
                columnIndexes.Add(indexedVariables
                    .First(indexedVariable => indexedVariable.Variable.Name == "CaseCATILive").Index);
                columnIndexes.Add(indexedVariables.First(indexedVariable => indexedVariable.Variable.Name == "LocType")
                    .Index);
                columnIndexes.Add(indexedVariables.First(indexedVariable => indexedVariable.Variable.Name == "MPRID")
                    .Index);
                columnIndexes.Add(indexedVariables
                    .First(indexedVariable => indexedVariable.Variable.Name == "PhoneList_1").Index);

                // Create a new record. Use the list of indexes to set the correct values.
                //DataTransferService.DataRecord dataRecord = new DataTransferService.DataRecord();
                var dataRecord = dataLevel.Records[0];
                dataRecord.Values = new object[dataLevel.Variables.Count()];
                dataRecord.Values[columnIndexes[0]] = "1";
                dataRecord.Values[columnIndexes[1]] = "0";
                dataRecord.Values[columnIndexes[2]] = strMPRID;
                dataRecord.Values[columnIndexes[3]] = "5551234567";


                // Add the new record to the list of records
                //var listRecords = dataLevel.Records.ToList();
                //listRecords.Add(dataRecord);
                //dataLevel.Records = listRecords.ToArray();
                dataLevel.Records[0] = dataRecord;


                //SurveyDataSrvc.ErrorMessage[] errorsSD = dataTransferSD.UpdateExistingRespondentsGeneralWithCatiScheduling(key, projectId, result.Result, true, KEYCOLUMN_DEFAULT, false, 0, CatiScheduling.Full);
            } while (!result.Token.LastDataSet);
        }


        /// <summary>
        ///     Login to the Confirmit API and return the security token used in subsequent requests.
        /// </summary>
        /// <returns></returns>
        private static string DoLogin(string APIUser, string APIPwd)
        {
            if (_SecToken != string.Empty)
                return _SecToken;

            Debug.WriteLine("Contacting Logon service...");
            var logon = new LogOnSoapClient();

            var SecToken = string.Empty;

            try
            {
                SecToken = logon.LogOnUser(APIUser, APIPwd);
                Debug.Write("Logged in.");
                _SecToken = SecToken;
                return SecToken;
            }
            catch (Exception ex)
            {
                Debug.Write("Failed to login.");
                Debug.WriteLine(ex.Message);
            }

            return string.Empty;
        }
    }
}