using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform;

namespace DispatchPlatform.Command
{
    public class DispatchLogBLL
    {
        /// <summary>
        /// 写调度日志
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dispathcNumber"></param>
        /// <param name="dispatchedNumbers"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public static bool WriteLog(CommControl.PublicEnums.EnumNormalCmd action, long dispathcNumber, string dispatchedNumbers, string memo)
        {
            if (dispathcNumber==0)
            {
                return false;
            }
           

            DB_Talk.Model.Data_DispatchLog log = new DB_Talk.Model.Data_DispatchLog();

            log.dt_DateTime = DateTime.Now;
            log.ManagerID = Pub.manageModel.ID;
            log.DispatchTypeID = action.GetHashCode();
            log.DispatchNumber = dispathcNumber;
            log.DispatchedNumbers = dispatchedNumbers;
            log.i_Result = 0;
            log.BoxID = Pub.manageModel.BoxID;
            log.i_State = 0;
            log.vc_Memo = memo;
            if ((new DB_Talk.BLL.Data_DispatchLog()).Add(log) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新调度结果
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dispathcNumber"></param>
        /// <param name="dispatchedNumbers"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool UpdateLog(CommControl.PublicEnums.EnumNormalCmd action, long dispathcNumber, string dispatchedNumbers, bool result)
        {
            bool b = false;
            try
            {
                List<DB_Talk.Model.Data_DispatchLog> lst = new DB_Talk.BLL.Data_DispatchLog().GetModelList(
                     string.Format("DispatchNumber={0} and DispatchTypeID='{1}' and DispatchedNumbers='{2}' and i_State=0 order by dt_datetime desc",
                     dispathcNumber, 
                     action.GetHashCode(),
                     dispatchedNumbers));

                if (lst != null && lst.Count > 0)
                {
                    bool isFisrt = true;
                    foreach (DB_Talk.Model.Data_DispatchLog item in lst)
                    {
                        if (result)
                        {
                            if (isFisrt==true)
                            {
                                item.i_Result = 1;
                                isFisrt = false;
                            }
                        }
                        else
                        {
                            item.i_Result = 0;
                        }
                        item.i_State = 1;
                        b = new DB_Talk.BLL.Data_DispatchLog().Update(item);
                    }
                   
                }
            }
            catch (Exception)
            {


            }
            return b;
        }

        /// <summary>
        /// 得到调度记录
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dispathcNumber"></param>
        /// <param name="dispatchedNumbers"></param>
        /// <returns></returns>
        public static DB_Talk.Model.Data_DispatchLog GetDispatchLog(CommControl.PublicEnums.EnumNormalCmd action, long dispathcNumber)
        {
            try
            {
                List<DB_Talk.Model.Data_DispatchLog> lst = new DB_Talk.BLL.Data_DispatchLog().GetModelList(
                string.Format("DispatchNumber={0} and DispatchTypeID='{1}' and i_State=0 order by dt_datetime desc", dispathcNumber, action.GetHashCode()));
                bool b = false;
                if (lst.Count > 0)
                {
                    return lst[0];
                }
            }
            catch (Exception)
            {
                
                
            }
           
            return null;
        }
    }
}
