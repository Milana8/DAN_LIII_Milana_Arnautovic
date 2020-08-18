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

        /// <summary>
        /// Get all employee from db
        /// </summary>
        /// <returns></returns>
        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwEmployee> GetAllEmployeeView()
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool AddEmployee(vwEmployee addemployee)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblUser user = new tblUser
                    {
                        DateOfBirth = addemployee.DateOfBirth,
                        Email = addemployee.Email,
                        NameSurname = addemployee.NameSurname,
                        Pasword = addemployee.Pasword,
                        Username = addemployee.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    addemployee.UserID = user.UserID;
                    tblEmployee employee = new tblEmployee
                    {
                        UserID = user.UserID,
                        Citizenship = addemployee.Citizenship,
                        Engagment = addemployee.Engagment,
                        Gender = addemployee.Gender,
                        HotelFloor = addemployee.HotelFloor,
                        

                    };
                    context.tblEmployees.Add(employee);
                    context.SaveChanges();
                    addemployee.EmployeeID = employee.EmployeeID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool CanCreateEmployee(vwEmployee employee)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    
                    var managers = context.vwManagers.Where(x => x.HotelFloor == employee.HotelFloor).FirstOrDefault();
                    if (managers != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        public vwEmployee FindEmployee(string username)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    vwEmployee employee = (from e in context.vwEmployees where e.Username == username select e).First();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool AddAbsence(vwAbsence absence)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblAbsence newAbsence = new tblAbsence
                    {
                        FirstDay = absence.FirstDay,
                        LastDay = absence.LastDay,
                        StatusRequest = "on hold",
                        Reason = absence.Reason,
                        UserID = absence.UserID
                    };
                    context.tblAbsences.Add(newAbsence);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        
        public List<vwAbsence> GetRequests(vwEmployee employee)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    return context.vwAbsences.Where(x => x.UserID == employee.UserID).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
       
        public bool DeleteRequest(vwAbsence request)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblAbsence requestToDelete = context.tblAbsences.Where(x => x.AbsenceID == request.AbsenceID).FirstOrDefault();
                    requestToDelete.StatusRequest = "deleted";
                    requestToDelete.Reason = request.Reason;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        
        public bool RejectRequest(vwAbsence request)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblAbsence requestToReject = context.tblAbsences.Where(x => x.AbsenceID == request.AbsenceID).FirstOrDefault();
                    requestToReject.StatusRequest = "rejected";
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        
        public bool ApproveRequest(vwAbsence request)
        {
            try
            {
                using (DAN_LIIIEntities context = new DAN_LIIIEntities())
                {
                    tblAbsence requestToApprove = context.tblAbsences.Where(x => x.AbsenceID == request.AbsenceID).FirstOrDefault();
                    requestToApprove.StatusRequest = "approved";
                    context.SaveChanges();
                    context.SaveChanges();
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
  