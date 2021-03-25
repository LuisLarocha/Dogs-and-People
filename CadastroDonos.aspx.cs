using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Dog_and_People
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strConexao = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindListaCaes();
            }

        }

        protected void btnCadastrarDono_Click(object sender, EventArgs e)
        {
            string strNomeDono = null;          
            MySqlConnection conexao = null;
            MySqlCommand comando = null;

            try
            {
                if (txtDono.Text.Trim() != string.Empty)
                {
                    strNomeDono = txtDono.Text.Trim();
                    CadastrarDono(strNomeDono);
                }
                else 
                {
                    lblMensagem.Text = "Informe o Nome do Dono do(s) respectivo(s) cão(es)";
                    lblMensagem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                conexao = null;
                conexao = null;
                comando = null;
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public void BindListaCaes()
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
                da = new MySqlDataAdapter("SELECT caoID, nome " +
                                            "FROM caes " +
                                            "ORDER BY nome ASC", Conexao);

                Conexao.Open();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cblCaes.DataTextField = "nome";
                    cblCaes.DataValueField = "caoID";
                    cblCaes.DataSource = dt;
                    cblCaes.DataBind();
                }
                else {
                    lblMensagem.Text = "Necessário efetuar o cadastro do cão antes no sistema";
                }
                Conexao.Close();
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

        public void CadastrarCao(Int32 pDono) 
        {
            MySqlConnection conexao = null;
            MySqlCommand comando = null;
            Int32 caoID;

            try
            {
                if (cblCaes.Items.Count > 0)
                {
                    conexao = new MySqlConnection(strConexao);
                    conexao.Open();

                    comando = new MySqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;

                    for (int i = 0; i < cblCaes.Items.Count; i++)
                    {
                        if (cblCaes.Items[i].Selected)
                        {
                            caoID = Convert.ToInt32(cblCaes.Items[i].Value);
                            comando.CommandText = "INSERT INTO caes_dono (caes_donoID, caoID, donoID) values (0, " + caoID + ", '" + pDono + "')";
                            comando.ExecuteNonQuery();
                        }
                    }
                    conexao.Close();
                }
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
                comando = null;
            }
        }

        public void CadastrarDono(string pStrDono)
        {
            MySqlConnection conexao = null;
            MySqlCommand comando1 = null;
            MySqlCommand comando2 = null;
            MySqlDataAdapter da = null;
            DataTable dt = null;

            try
            {
               
                conexao = new MySqlConnection(strConexao);
                conexao.Open();

                comando1 = new MySqlCommand();
                comando1.Connection = conexao;
                comando1.CommandType = CommandType.Text;

                comando1.CommandText = "INSERT INTO donos (donoID, nome) values (0,'" + pStrDono + "')";
                comando1.ExecuteNonQuery();

                comando2 = new MySqlCommand();
                comando2.Connection = conexao;
                comando2.CommandType = CommandType.Text;

                da = new MySqlDataAdapter(comando2);
                dt = new DataTable();              
                da = new MySqlDataAdapter("SELECT donoID, nome FROM donos WHERE nome = '" + pStrDono + "'", conexao);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Int32 caoID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    CadastrarCao(caoID);
                }
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
                 da = null;
                 dt = null;

            }
        }



    }
}