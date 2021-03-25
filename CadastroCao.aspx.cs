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
    public partial class CadastroCao : System.Web.UI.Page
    {

        string strConexao = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDDL();
                lblMensagem.Text = "";
                lblMensagem.Visible = false;
            }
        }

        protected void btnCadastrarDono_Click(object sender, EventArgs e)
        {
            string strRaca = null;
            string strNomeCao = null;
            try
            {
                lblMensagem.Text = "";
                lblMensagem.Visible = false;

                strRaca = txtRaca.Text.Trim();
                strNomeCao = txtCao.Text.Trim();

                if (strRaca.Trim() != string.Empty && strNomeCao.Trim() != string.Empty)
                {
                    CadastrarCao(strRaca, strNomeCao);
                }
                else { 
                    lblMensagem.Text = "Favor informe os dados do cão a ser cadastrado no sistema";
                    lblMensagem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
    
        }

        public void BindDDL()
        {
            MySqlConnection Conexao = null;
            MySqlCommand comando = null;
            MySqlDataAdapter da = null;
            DataTable dt = null;

            try
            {

                Conexao = new MySqlConnection(strConexao);               

                da = new MySqlDataAdapter(comando);
                dt = new DataTable();
                da = new MySqlDataAdapter("SELECT donoID, nome " +
                                            "FROM donos " +
                                            "ORDER BY nome ASC", Conexao);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ddlDonos.DataSource = dt;
                    ddlDonos.DataTextField = "nome";
                    ddlDonos.DataValueField = "donoID";
                    ddlDonos.DataBind();

                }                      
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
                dt = null;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public void CadastrarCao(string pRaca, string pNome)
        {

            MySqlConnection conexao = null;
            MySqlCommand comando1 = null;
            MySqlCommand comando2 = null;
            MySqlCommand comando3 = null;
            MySqlDataAdapter da = null;
            DataTable dt = null;

            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();

                comando1 = new MySqlCommand();
                comando1.Connection = conexao;
                comando1.CommandType = CommandType.Text;

                comando1.CommandText = "INSERT INTO caes (caoID, nome, raca) VALUES (0,'" + pNome + "','" + pRaca + "')";
                comando1.ExecuteNonQuery();


                comando2 = new MySqlCommand();
                comando2.Connection = conexao;
                comando2.CommandType = CommandType.Text;

                da = new MySqlDataAdapter(comando2);
                dt = new DataTable();
                da = new MySqlDataAdapter("SELECT caoID, nome, raca FROM caes WHERE nome = '" + pNome + "'", conexao);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Int32 caoID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Int32 donoID = Convert.ToInt32(ddlDonos.Items[0].Value);

                    comando3 = new MySqlCommand();
                    comando3.Connection = conexao;
                    comando3.CommandType = CommandType.Text;
                    comando3.CommandText = "INSERT INTO caes_dono (caes_donoID, caoID, donoID) VALUES (0," + caoID + "," + donoID + ")";
                    comando3.ExecuteNonQuery();

                }
                

                conexao.Close();

                lblMensagem.Text = "Dados cadastrados com sucesso!";
                lblMensagem.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                conexao = null;
                comando1 = null;
                comando2 = null;
                comando3 = null;
                da = null;
                dt = null;
            }

        }

    }

}