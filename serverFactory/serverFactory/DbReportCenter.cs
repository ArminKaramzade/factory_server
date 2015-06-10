using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverFactory
{
    class DbReportCenter
    {
        private ServerContainer serverDb;
        public DbReportCenter(ServerContainer con)
        {
            serverDb = con;
        }

        public bool newReport(Report r, ReportCategory rc, Attachments atach = null)
        {

            Report newReport = serverDb.Reports.Create();
            ReportCategory newRc = serverDb.ReportCategories.Create();
            Attachments newAtach = serverDb.Attachments.Create();

            newReport.Sender_ID = r.Sender_ID;
            newReport.Sender = r.Sender;
            newReport.Recipient = r.Recipient;
            newReport.Recipient_ID = r.Recipient_ID;
            newReport.SendDate = r.SendDate;
            newReport.isRead = r.isRead;
            newReport.isMark = r.isMark;
            newReport.Title = r.Title;
            newReport.Description = r.Description;
            if (atach != null)
                newReport.Attachment = newAtach;
            newReport.ReportCategory = newRc;


            newRc.Reports.Add(newReport);
            newRc.Title = rc.Title;

            newAtach.FileLocation = atach.FileLocation;
            newAtach.Report = newReport;
            newAtach.uploadTime = atach.uploadTime;

            serverDb.Reports.Add(newReport);
            try
            {
                serverDb.SaveChanges();
                Console.WriteLine("000000000000\n");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("goh \n" + e.StackTrace + "    ljkkjhghj    " + e.Message);
                return false;
            }
        }


        public int newReportgetId(Report r, ReportCategory rc, Attachments atach = null)
        {

            Report newReport = serverDb.Reports.Create();
            ReportCategory newRc = serverDb.ReportCategories.Create();
            Attachments newAtach = serverDb.Attachments.Create();

            newReport.Sender_ID = r.Sender_ID;
            newReport.Sender = r.Sender;
            newReport.Recipient = r.Recipient;
            newReport.Recipient_ID = r.Recipient_ID;
            newReport.SendDate = r.SendDate;
            newReport.isRead = r.isRead;
            newReport.isMark = r.isMark;
            newReport.Title = r.Title;
            newReport.Description = r.Description;
            if (atach != null)
                newReport.Attachment = newAtach;
            newReport.ReportCategory = newRc;


            newRc.Reports.Add(newReport);
            newRc.Title = rc.Title;

            newAtach.FileLocation = atach.FileLocation;
            newAtach.Report = newReport;
            newAtach.uploadTime = atach.uploadTime;

            serverDb.Reports.Add(newReport);
            try
            {
                serverDb.SaveChanges();
                Console.WriteLine("000000000000\n");
                return newReport.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("goh \n" + e.StackTrace + "    ljkkjhghj    " + e.Message);
                return 0;
            }
        }

        //public bool setServerId(int id)
        //{
        //    serverDb.Reports.Where(s => s.Id == id).First().ServerId = id;
        //    try
        //    {
        //        serverDb.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public List<ReportCategory> getCategoryList()
        //{
        //    var s1 = from s in serverDb.ReportCategories select s;
        //    var s2 = s1.ToList();
        //    return s2;
        //}

        //public List<User> getAllowedRecipientsList()
        //{
        //    var s = from s1 in serverDb.Users select s1;
        //    var s2 = s.ToList();
        //    return s2;
        //}



        //public ReportCategory getReportCategory(Int32 Id)
        //{
        //    var RepCat = serverDb.ReportCategories.Where(s => s.Id == Id).First();
        //    return RepCat;
        //}

        //public Attachments newAttachment(Report r, string fileLoc)
        //{

        //    Attachments newAtach = serverDb.Attachments.Create();
        //    newAtach.FileLocation = fileLoc;
        //    newAtach.Report = r;
        //    newAtach.uploadTime = DateTime.Now;
        //    serverDb.Attachments.Add(newAtach);
        //    try
        //    {
        //        serverDb.SaveChanges();
        //        return newAtach;
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}

        //public List<Report> getAllReportList()
        //{

        //    var s = from s1 in serverDb.Reports select s1;
        //    var s2 = s.ToList();
        //    return s2;

        //}

        //public List<Report> getSentReportList()
        //{
        //    var rep = serverDb.Reports.Where(r => r.Sender_ID == SessionInfos.login_user.Id).ToList();
        //    return rep;
        //}
        //public List<Report> getRecievedList()
        //{
        //    var rep = serverDb.Reports.Where(r => r.Recipient_ID == SessionInfos.login_user.Id).ToList();
        //    return rep;
        //}

        public bool deleteReport(Int32 ID)
        {
            using (serverDb)
            {
                Report r = serverDb.Reports.Where(i => i.Id == ID).First();
                serverDb.Reports.Remove(r);
            }

            try
            {
                serverDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Report getReportDetails(int id)
        {
            Report r = serverDb.Reports.Where(iid => iid.Id == id).First();
            return r;
        }

        public bool markReport(int id)
        {
            serverDb.Reports.Where(iid => iid.Id == id).First().isMark = true;
            serverDb.SaveChanges();
            return true;
        }

        public bool readReport(int id)
        {
            serverDb.Reports.Where(iid => iid.Id == id).First().isRead = true;
            return true;
        }

        public int GetServerReportId(int reportId)
        {
            return serverDb.Reports.Where(iid => iid.Id == reportId).First().Id;
        }

        public Tuple<Report, ReportCategory, Attachments> GetReportDetails(int reportId)
        {
            Report r = serverDb.Reports.Where(s => s.Id == reportId).First();
            Tuple<Report, ReportCategory, Attachments> t = new Tuple<Report, ReportCategory, Attachments>(r, r.ReportCategory, r.Attachment);
            return t;
        }
    }
}
