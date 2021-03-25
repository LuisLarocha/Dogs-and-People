using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Dog_and_People
{
    public partial class AlterarDono : System.Web.UI.Page
    {
        string strConexao = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Int32 donoID = Convert.ToInt32(Request.QueryString["donoID"].ToString());
                PreencherCampos(donoID);
            }
        }

        public void PreencherCampos(Int32 pDonoID)
        {

            MySqlConnection Conexao = null;
            MySqlCommand comando = null;
            MySqlDataAdapter da = null;
            DataSet ds = null;

            try
            {

                Conexao = new MySqlConnection(strConexao);
                comando = new MySqlCommand();

                da = new MySqlDataAdapter(comando);
                ds = new DataSet();

                comando.Connection = Conexao;
                comando.CommandText = "SELECT donoID, nome " +
                                        "FROM donos WHERE donoID = " + pDonoID;

                Conexao.Open();
                da.Fill(ds, "pDonoID");
                Conexao.Close();

                txtDono.Text = ds.Tables[0].Rows[0][1].ToString();                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                Conexao = null;
                comando = null;
                da = null;
                ds = null;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAlterarDono_Click(object sender, EventArgs e)
        {
            string strNomeDono = null;
            MySqlConnection conexao = null;
            MySqlCommand comando = null;

            try
            {
                Int32 donoID = Convert.ToInt32(Request.QueryString["donoID"].ToString());
                strNomeDono = txtDono.Text.Trim();

                conexao = new MySqlConnection(strConexao);
                conexao.Open();

                comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE donos SET nome = '" + strNomeDono + "' WHERE donoID = " + donoID;
                comando.ExecuteNonQuery();

                lblMensagem.Text= "Dono alterado com sucesso!";
                lblMensagem.Visible = true;
                txtDono.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                conexao = null;
                comando = null;
            }
        }
    }
}