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
    public partial class AlterarCao : System.Web.UI.Page
    {

        string strConexao = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                Int32 caoID = Convert.ToInt32(Request.QueryString["caoID"].ToString());
                PreencherCampos(caoID);
            }         
            
        }

        public void PreencherCampos(Int32 pCaoID) 
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
                comando.CommandText = "SELECT caoID, nome, raca " +
                                        "FROM caes WHERE caoID = " + pCaoID;

                Conexao.Open();
                da.Fill(ds, "caes_dono");
                Conexao.Close();

                txtCao.Text = ds.Tables[0].Rows[0][1].ToString();
                txtRaca.Text = ds.Tables[0].Rows[0][2].ToString();                

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

        protected void btnAlterarCao_Click(object sender, EventArgs e)
        {
            string strNomeCao = null;
            string strRacaCao = null;
            MySqlConnection conexao = null;
            MySqlCommand comando = null;

            try
            {
                Int32 caoID = Convert.ToInt32(Request.QueryString["caoID"].ToString());
                strNomeCao = txtCao.Text.Trim();
                strRacaCao = txtRaca.Text.Trim();

                conexao = new MySqlConnection(strConexao);
                conexao.Open();

                comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE caes SET nome = '" + strNomeCao + "' , raca = '" + strRacaCao + "' WHERE caoID = " + caoID;
                comando.ExecuteNonQuery();

                lblMensagem.Text = "Cao alterado com sucesso!";
                lblMensagem.Visible = true;
                txtCao.Text = "";
                txtRaca.Text = "";
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
    
}