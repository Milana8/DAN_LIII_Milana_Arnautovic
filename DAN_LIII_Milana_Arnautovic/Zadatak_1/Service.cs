using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1
{
    class Service
    {

        /// <summary>
        /// Get All Users from db
        /// </summary>
        /// <returns></returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// Get all managers from db
        /// </summary>
        /// <returns></returns>
        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    List<tblManager> list = new List<tblManager>();
                    list = (from x in context.tblManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwManager> GetAllManagerView()
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool IsUser(string username)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    vwManager manager = (from e in context.vwManagers where e.Username == username select e).First();

                    if (manager == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Find the manager by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public vwManager FindManager(string username)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    vwManager manager = (from e in context.vwManagers where e.Username == username select e).First();
                    return manager;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool AddManager(vwManager addmanager)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblUser user = new tblUser
                    {
                        DateOfBirth = addmanager.DateOfBirth,
                        Email = addmanager.Email,
                        NameSurname = addmanager.NameSurname,
                        Pasword =addmanager.Pasword,
                        Username = addmanager.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    addmanager.UserID = user.UserID;
                    tblManager manager = new tblManager
                    {
                        UserID = addmanager.UserID,
                        Exprience = addmanager.Exprience,
                        HotelFloor = addmanager.HotelFloor,
                        Qualifications = addmanager.Qualifications
                    };
                    context.tblManagers.Add(manager);
                    context.SaveChanges();
                    addmanager.ManagerID = manager.ManagerID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}
