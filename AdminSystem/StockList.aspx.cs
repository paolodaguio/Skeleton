﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    Int32 ClothesNo;

    
    //this function handles the load event 
    protected void Page_Load(object sender, EventArgs e)
    {
        ClothesNo = Convert.ToInt32(Session["ClothesNo"]);
        //if this is the first time the page is dsiplayed
        if (IsPostBack == false)
        {
           
            
                //update the list box
                DisplayStocks();

            
            
        }

    }
    void DisplayStocks()
    {
        clsStockCollection Stocks = new clsStockCollection();
        Stocks.ThisStock.Find(ClothesNo);
        lstStockList.DataSource = Stocks.StockList;
        lstStockList.DataValueField = "ClothesNo";
        lstStockList.DataTextField = "ClothesDescription";
        lstStockList.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["ClotheNo"] = 1;
        Response.Redirect("StockDataEntry.aspx");
    }
   

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        Int32 ClothesNO;
        if (lstStockList.SelectedIndex != 1)
        {
            ClothesNO = Convert.ToInt32(lstStockList.SelectedValue);
            Session["ClothesNo"] = ClothesNO;
            Response.Redirect("StockDataEntry.aspx");

        }
        else
        {
            lblError.Text = "Please select a record to delete from the list";

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 ClothesNo;
        if (lstStockList.SelectedIndex != -1)
        {
            ClothesNo = Convert.ToInt32(lstStockList.SelectedValue);
            Session["ClothesNo"] = ClothesNo;
            Response.Redirect("DeleteStock.aspx");
        }
        else
        {
            lblError.Text = "Please select a record to delete from the list";

        }

    }

    protected void BtnApply_Click(object sender, EventArgs e)
    {
        clsStockCollection Orders = new clsStockCollection();
        Orders.ReportByClothesDescription(txtFilter.Text);
        lstStockList.DataSource = Orders.StockList;
        lstStockList.DataValueField = "ClothesNo";
        lstStockList.DataTextField = "ClothesDescription";
        lstStockList.DataBind();

    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        clsStockCollection Stocks = new clsStockCollection();
        Stocks.ReportByClothesDescription("");
        txtFilter.Text = "";
        lstStockList.DataSource = Stocks.StockList;
        lstStockList.DataValueField = "ClothesNo";
        lstStockList.DataTextField = "ClothesDescription";
        lstStockList.DataBind();
    }
}