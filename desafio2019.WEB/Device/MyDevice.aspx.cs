using desafio2019.Entity.MySql;
using desafio2019.Logic.MySql;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace desafio2019.WEB.Device
{
    public partial class MyDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Devices_Lista();
            }
        }

        private void Devices_Lista()
        {
            try
            {
                LoDevices objLo = new LoDevices();
                object objDevices = new object();

                objDevices = objLo.Devices_Lista();
                grvListado.DataSource = objDevices;
                grvListado.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //protected void btnEditar_Click(object sender, EventArgs e)
        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:BuscarItem();", true);
           

                CargaConnection();
                CargaDevice();
                CargaSensor();
                CargaOperativeSystem();

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                DataTable dt = new DataTable();

                int index = Convert.ToInt32(e.CommandArgument);
                Label rowid = (Label)grvListado.Rows[index].FindControl("lblrowid");

              

                dt = objLo.Devices_Selecionar(Convert.ToInt32(rowid.Text));

                ddlTypeConnection.SelectedValue = dt.Rows[0]["ConnectionID"].ToString();
                ddlTypeDevice.SelectedValue = dt.Rows[0]["DeviceID"].ToString();
                ddlTypeSensor.SelectedValue = dt.Rows[0]["SensorID"].ToString();
                ddlOperativeSystem.SelectedValue = dt.Rows[0]["OperSysID"].ToString();
                //txtIp.Text = dt.Rows[0]["NameDevice"].ToString();
                txtNameDevice.Text = dt.Rows[0]["NameDevice"].ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void btntxt_Command(object sender, CommandEventArgs e)
        {

            try
            {

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                DataTable dt = new DataTable();


                int index = Convert.ToInt32(e.CommandArgument);
                Label rowid = (Label)grvListado.Rows[index].FindControl("lblrowid");



                dt = objLo.Devices_Selecionar(Convert.ToInt32(rowid.Text));



                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Reporte");
                workSheet.TabColor = System.Drawing.Color.Black;


                if (dt.Rows.Count > 0)
                {
                    workSheet.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light8);

                }

                workSheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                workSheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
                // workSheet.PrinterSettings.RepeatRows = workSheet.Cells["1:" + numColumnas];
                workSheet.PrinterSettings.Orientation = eOrientation.Landscape;
                excel.Workbook.Properties.Title = "Reporte";
                excel.Workbook.Properties.Author = "Sistemas ";
                excel.Workbook.Properties.Comments = "Maestro ";

                excel.Workbook.Properties.Company = "Device S.A";



                DateTime fechaHora = new DateTime();
                fechaHora = DateTime.Now;

                string nombre = "descarga-A" + fechaHora.ToString("yyyyMMddHHmmss") + ".xlsx";
                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + nombre);
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void chkValidarIp_CheckedChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:BuscarItem();", true);

            if (!chkValidarIp.Checked)
            {
                lblMensaje.Text = string.Empty;
                return;
            }

            if (IsValidIp(txtIp.Text.Trim()))
            {
                lblMensaje.Text = "Ip Validada";
            }
            else
            {
                lblMensaje.Text = "Ip Incorrecta";
            }

        }

        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }

        private void CargaConnection()
        {
            try
            {
                LoConnection objLo = new LoConnection();
                object objConnection = new object();

                objConnection = objLo.CargaConnection();

                ddlTypeConnection.DataValueField = "rowid";
                ddlTypeConnection.DataTextField = "description";
                ddlTypeConnection.DataSource = objConnection;
                ddlTypeConnection.DataBind();
                ddlTypeConnection.Items.Insert(0, new ListItem("---Select---", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaDevice()
        {
            try
            {
                LoDevice_Type objLo = new LoDevice_Type();
                object objDevice = new object();

                objDevice = objLo.CargaDevice_Type();

                ddlTypeDevice.DataValueField = "rowid";
                ddlTypeDevice.DataTextField = "description";
                ddlTypeDevice.DataSource = objDevice;
                ddlTypeDevice.DataBind();
                ddlTypeDevice.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaSensor()
        {
            try
            {
                LoSensor objLo = new LoSensor();
                object objSensor = new object();

                objSensor = objLo.CargaSensor();

                ddlTypeSensor.DataValueField = "rowid";
                ddlTypeSensor.DataTextField = "description";
                ddlTypeSensor.DataSource = objSensor;
                ddlTypeSensor.DataBind();
                ddlTypeSensor.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaOperativeSystem()
        {
            try
            {
                LoOperativeSystem objLo = new LoOperativeSystem();
                object objOperativeSystem = new object();

                objOperativeSystem = objLo.CargaOperativeSystem();

                ddlOperativeSystem.DataValueField = "rowid";
                ddlOperativeSystem.DataTextField = "description";
                ddlOperativeSystem.DataSource = objOperativeSystem;
                ddlOperativeSystem.DataBind();
                ddlOperativeSystem.Items.Insert(0, new ListItem("---Select---", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            lblMensaje.Text = string.Empty;

            try
            {

                if (!IsValidIp(txtIp.Text))
                {
                    lblMensaje.Text = "Ip Incorrecta";
                    return;
                }

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                objEn.ConnectionID = Convert.ToInt32(ddlTypeConnection.SelectedValue);
                objEn.NameDevice = txtNameDevice.Text.Trim();
                objEn.DeviceID = Convert.ToInt32(ddlTypeDevice.SelectedValue);
                objEn.SensorID = Convert.ToInt32(ddlTypeSensor.SelectedValue);
                objEn.OperSysID = Convert.ToInt32(ddlTypeConnection.SelectedValue);

                msg = objLo.Devices_Editar(objEn);
                if (msg.ToUpper() == "EXITO")
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }





        }


    }
}