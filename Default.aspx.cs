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
    public partial class _Default : Page
    {
        string strConexao = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblMensagem.Text = "";
                lblMensagem.Visible = false;

                pnlCaes.Visible = false;
                pnlDonos.Visible = false;
                Bind();
            }
        }

        public void Bind()
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
                comando.CommandText = "SELECT caes.nome AS nomeCao, donos.nome AS nomeDono, caes.raca " +
                                      "FROM caes_dono " +
                                      "INNER JOIN donos ON caes_dono.donoID = donos.donoID " +
                                      "INNER JOIN caes ON caes_dono.caoID = caes.caoID " +
                                      "ORDER BY nomeCao ASC";

                Conexao.Open();
                da.Fill(ds, "caes_dono");
                Conexao.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDonosCaes.DataSource = ds.Tables[0].DefaultView;
                    DataBind();
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
                ds = null;
            }
        }

        public void ConsultarDono(string pNome)
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
                                     "FROM donos " +
                                     "WHERE donos.nome = '" + pNome + "'";

                Conexao.Open();
                da.Fill(ds, "donos");
                Conexao.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlCaesDono.Visible = false;
                    gvDonos.DataSource = ds.Tables[0].DefaultView;
                    DataBind();
                }
                else
                {
                    lblMensagem.Text = "O dono informado não está cadastrado";
                    lblMensagem.Visible = true;
                }
              

                pnlDonos.Visible = true;
                pnlCaes.Visible = false;


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

        public void ConsultarCao(string pNome)
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
                                     "FROM caes " +
                                     "WHERE caes.nome = '" + pNome + "'";

                Conexao.Open();
                da.Fill(ds, "caes");
                Conexao.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlCaesDono.Visible = false;
                    gvCaes.DataSource = ds.Tables[0].DefaultView;
                    DataBind();
                }
                else
                {
                    lblMensagem.Text = "O cão informado não está cadastrado";
                    lblMensagem.Visible = true;
                }
                
                pnlCaes.Visible = true;

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

        protected void btnConsultarDono_Click(object sender, EventArgs e)
        {
            string strNomeDono = null;

            try
            {
                lblMensagem.Text = "";
                lblMensagem.Visible = false;

                strNomeDono = txtDono.Text.Trim();

                if (strNomeDono != "")
                {
                    ConsultarDono(strNomeDono);
                }
                else
                {
                    lblMensagem.Text = "Informe o Nome do Dono para a consulta";
                    lblMensagem.Visible = true;
                    txtDono.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void btnConsultarCao_Click(object sender, EventArgs e)
        {
            string strNomeCao = null;

            try
            {
                lblMensagem.Text = "";
                lblMensagem.Visible = false;

                strNomeCao = txtCao.Text.Trim();

                if (strNomeCao != "")
                {
                    ConsultarCao(strNomeCao);
                }
                else
                {
                    lblMensagem.Text = "Informe o Nome do Cão para a consulta";
                    lblMensagem.Visible = true;
                    txtCao.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        protected void btnCadastrarDonos_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroDonos.aspx");
        }

        protected void btnCadastrarCaes_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCao.aspx");
        }

        public void ExcluirDono(int pDonoID)
        {
            MySqlConnection Conexao = null;
            MySqlCommand comando1 = null;
            MySqlCommand comando2 = null;

            try
            {
                Conexao = new MySqlConnection(strConexao);

                comando1 = new MySqlCommand();
                comando1.Connection = Conexao;
                comando1.CommandText = "DELETE FROM caes_dono WHERE donoID =  " + pDonoID + "";

                Conexao.Open();
                comando1.ExecuteNonQuery();
                Conexao.Close();

                comando2 = new MySqlCommand();
                comando2.Connection = Conexao;
                comando2.CommandText = "DELETE FROM donos WHERE donoID =  " + pDonoID + "";

                Conexao.Open();
                comando2.ExecuteNonQuery();
                Conexao.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                Conexao = null;
                comando1 = null;
                comando2 = null;

            }
        }

        public void ExcluirCao(int pCaoID)
        {
            MySqlConnection Conexao = null;
            MySqlCommand comando1 = null;
            MySqlCommand comando2 = null;

            try
            {
                Conexao = new MySqlConnection(strConexao);

                comando1 = new MySqlCommand();               
                comando1.Connection = Conexao;
                comando1.CommandText = "DELETE FROM caes_dono WHERE caoID =  " + pCaoID + "";

                Conexao.Open();
                comando1.ExecuteNonQuery();
                Conexao.Close();

                comando2 = new MySqlCommand();
                comando2.Connection = Conexao;
                comando2.CommandText = "DELETE FROM caes WHERE caoID =  " + pCaoID + "";

                Conexao.Open();
                comando2.ExecuteNonQuery();
                Conexao.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                Conexao = null;
                comando1 = null;
                comando2 = null;
            }
        }

        protected void gvDonos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Deletar"))
                {
                    Int32 donoID = Convert.ToInt32(this.gvDonos.Rows[id].Cells[0].Text);

                    ExcluirDono(donoID);
                    Bind();
                    lblMensagem.Text = "Dono excluido com sucesso!";
                    lblMensagem.Visible = true;
                    txtDono.Text = "";

                }

                if (e.CommandName.Equals("Alterar"))
                {
                    Int32 donoID = Convert.ToInt32(this.gvDonos.Rows[id].Cells[0].Text);
                    string url;
                    url = "AlterarDono.aspx?donoID=" + donoID;
                    Response.Redirect(url);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }   
        }

        protected void gvCaes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Deletar"))
                {
                    Int32 caoID = Convert.ToInt32(this.gvCaes.Rows[id].Cells[0].Text);

                    ExcluirCao(caoID);
                    Bind();
                    lblMensagem.Text = "Cão excluido com sucesso!";
                    lblMensagem.Visible = true;

                    txtCao.Text = "";
                }

                if (e.CommandName.Equals("Alterar"))
                {
                    Int32 caoID = Convert.ToInt32(this.gvCaes.Rows[id].Cells[0].Text);
                    string url;
                    url = "AlterarCao.aspx?caoID=" + caoID;
                    Response.Redirect(url);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }

}