using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_BLL;
using WR_Model;

namespace WR_EAMS
{
    public partial class Score : System.Web.UI.Page
    {
        ScoreManager scoreManager = new ScoreManager();

        Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["students"] != null)
                {
                    student = Session["students"] as Student;
                    if (!IsPostBack)
                    {
                        IntitData(student);
                    }
                }
                else
                {
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
            }
        }

        private void IntitData(Student student,string score="")
        {
            int currentPage = int.Parse(Current_Page.Text); //当前页码
            
            PagedDataSource ps = new PagedDataSource();
            if (score != "")
            {
                ps.DataSource = scoreManager.CheckScoreBySco(score,student.SId).Tables["myTable"].DefaultView;
            }
            else
            {
                ps.DataSource = scoreManager.CheckAllScore(student.SId).Tables["myTable"].DefaultView;
            }
            
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 10; //显示的数量
            ps.CurrentPageIndex = currentPage - 1; //取得当前页的页码
            Score_Count.Text = ps.DataSourceCount.ToString(); //显示数据总条数
            All_Page.Text = ps.PageCount.ToString();    //显示总页数

            Score_gv.DataSource = ps;
            Score_gv.DataBind();

            Btn_First.Enabled = true;
            Btn_Last.Enabled = true;
            Btn_next.Enabled = true;
            Btn_prev.Enabled = true;

            if (currentPage == 1)
            {
                Btn_First.Enabled = false;//不显示第一页按钮
                Btn_prev.Enabled = false;//不显示上一页按钮
            }
            if (currentPage == ps.PageCount)
            {
                Btn_Last.Enabled = false;//不显示下一页
                Btn_next.Enabled = false;//不显示最后一页
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string science = ddr_Course.Text;   //获取选择的学科
            IntitData(student, science);
        }

        protected void Btn_First_Click(object sender, EventArgs e)
        {
            Current_Page.Text = "1";
            IntitData(student);
        }

        protected void Btn_prev_Click(object sender, EventArgs e)
        {
            Current_Page.Text = Convert.ToString(Convert.ToInt32(Current_Page.Text) - 1);
            IntitData(student);
        }

        protected void Btn_next_Click(object sender, EventArgs e)
        {
            Current_Page.Text = Convert.ToString(Convert.ToInt32(Current_Page.Text) + 1);
            IntitData(student);
        }

        protected void Btn_Last_Click(object sender, EventArgs e)
        {
            Current_Page.Text = All_Page.Text;
            IntitData(student);
        }

        protected void Btn_Search_All_Click(object sender, EventArgs e)
        {
            IntitData(student);
        }
    }
}