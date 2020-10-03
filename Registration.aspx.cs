using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;





public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string[] validFileTypes = { "doc", "docx" };
        string ext = System.IO.Path.GetExtension(FileUploadResume.PostedFile.FileName);
        bool isValidFile = false;
        try
        {
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) //checking whether the file is valid or not
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid File. Only " +
                               string.Join(",", validFileTypes) + " files are allowed..";
                return;
            }

            Employee emp = new Employee();
            emp.UserName = txtName.Text;
            emp.Email = txtEmail.Text.ToLower();
            emp.Password = txtPassword.Text;
            emp.Gender = rbtnListGender.SelectedItem.ToString();
            emp.DOB = txtDOB.Text.ToString();
            emp.Mobile = txtMobile.Text;
            emp.Country = txtCountry.Text;
            emp.City = txtCity.Text;
            emp.Address = txtAddress.Text;

            if (chkPhysical.Checked == true)
            {
                emp.physicallyChallenged = "yes";

            }
            else
            {
                emp.physicallyChallenged = "NO";

            }
            if (FileUploadResume.HasFile)
            {
                Stream fs = FileUploadResume.PostedFile.InputStream;
                emp.AttachedFileName = FileUploadResume.FileName.ToString();

                BinaryReader br = new BinaryReader(fs);
                emp.AttachedFileData = br.ReadBytes((Int32)fs.Length);
                br.Close();
                fs.Close();
            }

            //Adding Employee
            emp.Add();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Employee Added successfully";
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message;
            return;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //refreshing/reloading page to clear all the controls
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }
}