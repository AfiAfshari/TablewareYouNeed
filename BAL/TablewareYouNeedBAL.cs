﻿using DataAccessLayer;
using EntityModel;
using System;
using System.Collections.Generic;

namespace BAL
{
    public class TablewareYouNeedBAL
    {

        TablewareYouNeedDAL _objACCSDAL;



        public List<TablewareYouNeedEntity> GetProducts()
        {
            try
            {
                _objACCSDAL = new TablewareYouNeedDAL();
                return _objACCSDAL.GetProducts();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


    }
}