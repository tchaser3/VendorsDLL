/* Title:       Vendors Class
 * Date:        7-7-17
 * Author:      Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace VendorsDLL
{
    public class VendorsClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        VendorsDataSet aVendorsDataSet;
        VendorsDataSetTableAdapters.vendorsTableAdapter aVendorsTableAdapter;

        FindVendorByVendorIDDataSet aFindVendorByVendorIDDataSet;
        FindVendorByVendorIDDataSetTableAdapters.FindVendorByVendorIDTableAdapter aFindVencorByVendorIDTableAdapter;

        FindVendorByVendorNameDataSet aFindVendorByVendorNameDataSet;
        FindVendorByVendorNameDataSetTableAdapters.FindVendorByVendorNameTableAdapter aFindVendorByVendorNameTableAdapter;

        FindVendorByVendorPhoneNumberDataSet aFindVendorByVendorPhoneNumberDataSet;
        FindVendorByVendorPhoneNumberDataSetTableAdapters.FindVendorByVendorPhoneNumberTableAdapter aFindVendorByVendorPhoneNumberTableAdapter;

        InsertNewVendorEntryTableAdapters.QueriesTableAdapter aInsertNewVendorEntryTableAdapter;

        UpdateVendorEntryTableAdapters.QueriesTableAdapter aUpdateVendorEntryTableAdapter;

        FindVendorsSortedByVendorNameDataSet aFindVendorsSortedByVendorNameDataSet;
        FindVendorsSortedByVendorNameDataSetTableAdapters.FindVendorsSortedByVendorNameTableAdapter aFindVendorsSortedByVendorNameTableAdapter;

        public FindVendorsSortedByVendorNameDataSet FindVendorsSortedByVendorName()
        {
            try
            {
                aFindVendorsSortedByVendorNameDataSet = new FindVendorsSortedByVendorNameDataSet();
                aFindVendorsSortedByVendorNameTableAdapter = new FindVendorsSortedByVendorNameDataSetTableAdapters.FindVendorsSortedByVendorNameTableAdapter();
                aFindVendorsSortedByVendorNameTableAdapter.Fill(aFindVendorsSortedByVendorNameDataSet.FindVendorsSortedByVendorName);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Find Vendors Sorted By Vendor Name " + Ex.Message);
            }

            return aFindVendorsSortedByVendorNameDataSet;
        }
        public bool UpdateVendor(int intVendorID, string strVendorName, string strContactName, string strPhoneNumber, bool blnActive)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateVendorEntryTableAdapter = new UpdateVendorEntryTableAdapters.QueriesTableAdapter();
                aUpdateVendorEntryTableAdapter.UpdateVendor(intVendorID, strVendorName, strContactName, strPhoneNumber, blnActive);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Update Vendor " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertNewVendor(string strVendorName, string strContactName, string strPhoneNumber)
        {
            bool blnFatalError = false;

            try
            {
                aInsertNewVendorEntryTableAdapter = new InsertNewVendorEntryTableAdapters.QueriesTableAdapter();
                aInsertNewVendorEntryTableAdapter.InsertNewVendor(strVendorName, strPhoneNumber, strContactName);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Insert New Vendor " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindVendorByVendorPhoneNumberDataSet FindVendorByVendorPhoneNumber(string strPhoneNumber)
        {
            try
            {
                aFindVendorByVendorPhoneNumberDataSet = new FindVendorByVendorPhoneNumberDataSet();
                aFindVendorByVendorPhoneNumberTableAdapter = new FindVendorByVendorPhoneNumberDataSetTableAdapters.FindVendorByVendorPhoneNumberTableAdapter();
                aFindVendorByVendorPhoneNumberTableAdapter.Fill(aFindVendorByVendorPhoneNumberDataSet.FindVendorByVendorPhoneNumber, strPhoneNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Find Vendor By Vendor Phone Number " + Ex.Message);
            }

            return aFindVendorByVendorPhoneNumberDataSet;
        }
        public FindVendorByVendorNameDataSet FindVendorByVendorName(string strVendorName)
        {
            try
            {
                aFindVendorByVendorNameDataSet = new FindVendorByVendorNameDataSet();
                aFindVendorByVendorNameTableAdapter = new FindVendorByVendorNameDataSetTableAdapters.FindVendorByVendorNameTableAdapter();
                aFindVendorByVendorNameTableAdapter.Fill(aFindVendorByVendorNameDataSet.FindVendorByVendorName, strVendorName);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Find Vendor By Vendor Name " + Ex.Message);
            }

            return aFindVendorByVendorNameDataSet;
        }
        public FindVendorByVendorIDDataSet FindVendorByVendorID(int intVendorID)
        {
            try
            {
                aFindVendorByVendorIDDataSet = new FindVendorByVendorIDDataSet();
                aFindVencorByVendorIDTableAdapter = new FindVendorByVendorIDDataSetTableAdapters.FindVendorByVendorIDTableAdapter();
                aFindVencorByVendorIDTableAdapter.Fill(aFindVendorByVendorIDDataSet.FindVendorByVendorID, intVendorID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Find Vendor by Vendor ID " + Ex.Message);
            }

            return aFindVendorByVendorIDDataSet;
        }
        public VendorsDataSet GetVendorsInfo()
        {
            try
            {
                aVendorsDataSet = new VendorsDataSet();
                aVendorsTableAdapter = new VendorsDataSetTableAdapters.vendorsTableAdapter();
                aVendorsTableAdapter.Fill(aVendorsDataSet.vendors);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Get Vendors Info " + Ex.Message);
            }

            return aVendorsDataSet;
        }
        public void UpdateVendorsDB(VendorsDataSet aVendorsDataSet)
        {
            try
            {
                aVendorsTableAdapter = new VendorsDataSetTableAdapters.vendorsTableAdapter();
                aVendorsTableAdapter.Update(aVendorsDataSet.vendors);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vendors Class // Update Vendors DB " + Ex.Message);
            }
        }
    }
}
