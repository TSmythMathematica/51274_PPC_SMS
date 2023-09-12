/******************************************************************************
* Copyright © Mathematica Policy Research, Inc. 
* This code cannot be copied, distributed or used without the express written permission
* of Mathematica Policy Research, Inc. 
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace APITest
{
    [Serializable]
    public class ConfirmItAPIException : Exception
    {
        public string MPRID { set; get; }
        public string SurveyID { set; get; }

        public Dictionary<string, string> Data { set; get; }

        public Dictionary<string, string> ResponseDataToUpdate { set; get; }

        public Dictionary<string, string> DataToUpdate{ set; get; }

        public Dictionary<string, string> SchedulingDataToUpdate{ set; get; }

        public Exception InnException { set; get; }

        public ConfirmItAPIException () : base() { }
        public ConfirmItAPIException(string mprid, string surveryid, Exception inner)
        {
            MPRID = mprid;
            SurveyID = surveryid;
            InnException = inner;
        }

        public ConfirmItAPIException(string mprid, string surveryid, Dictionary<string, string> data, Exception inner)
        {
            MPRID = mprid;
            SurveyID = surveryid;
            InnException = inner;
            DataToUpdate = data;
        }

        public ConfirmItAPIException(string mprid, string surveryid, Dictionary<string, string> data,Dictionary<string, string> resdata, Dictionary<string, string> schdata, Exception inner)
        {
            MPRID = mprid;
            SurveyID = surveryid;
            InnException = inner;
            DataToUpdate = data;
            ResponseDataToUpdate = resdata;
            SchedulingDataToUpdate = schdata;
        }
    }
}