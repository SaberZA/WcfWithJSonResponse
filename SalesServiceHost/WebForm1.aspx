﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SalesServiceHost.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-default">
        <div class="container">
        <a class="navbar-brand" >Sale Service</a>
        </div>
      </nav>
    <div class="container">
    <form id="form1" role="form" runat="server">
        <div class="form-group customerForm">
            <label for="TextBox1">Name</label>
            <asp:TextBox ID="TextBox1" 
                    runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group customerForm">
            <label for="TextBox2">Address</label>
            <asp:TextBox ID="TextBox2" 
                    runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group customerForm">
            <label for="TextBox3">Email</label>
            <asp:TextBox ID="TextBox3" 
                    runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"
                    onclick="Button1_Click" Text="Save" />
        </div>

        
<p>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered gridView1"
        AllowPaging="True"  DataKeyNames="CustomerId,CustomerName"
            AllowSorting="True" AutoGenerateDeleteButton="True" 
            onrowdeleting="GridView1_RowDeleting">
        </asp:GridView>
</p>
    
       <h3> <asp:Label ID="Label1" runat="server" CssClass="text-info"
        Text=""></asp:Label> </h3>
        

    </form>
    </div>
    
    <div id="json">
        <% Response.Write(JsonResponse); %>

    </div>
    
    <script type="text/javascript">
        var rowCounter = 0;


        $("#ContentPlaceHolder1_GridView1 tr").each(function () {
            if ((rowCounter % 2) == 0) {
                $(this).attr("class", "success");
            } else {
                $(this).attr("class", "danger");
            }
            rowCounter++;
        });

    </script>
</asp:Content>
