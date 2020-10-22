<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <style type="text/css">
      
        .n1 {
            position:absolute;
            left:38%;
            top:35%;
            font:bolder;
            font-size:xx-large;            
        }
       .center {
  display: block;
  margin-left: auto;
  margin-right: auto;
}
       }
        .t1{
            position:absolute;
            top:40%;
            width:150px;
            height:35px;
             left:38%;
        }
         .t2{
            position:absolute;
            top:45%;
            width:150px;
            height:35px;
             left:38%;
        }
    .buttonstyle1 {
    background-color: #0094ff; /* Green */
    border: none;
    color: white;
    padding: 16px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    transition-duration: 0.4s;
    cursor: pointer;
    position:absolute;
    left:40%;
    top:80%
}
        .bigger{
            height:200%;
          
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <br />
    <table  height="120%" width="40%" align="center">
        <tr><td></td></tr>
       <tr><td>  <asp:Label runat="server" align="left" style="Tahoma; font-size:120%">Username:</asp:Label> <asp:TextBox  style="font-size:160%" id="username"   runat="server"></asp:TextBox></td></tr>
       <tr><td> <asp:Label runat="server" align="left" style="Tahoma; font-size:120%">Password:</asp:Label> &nbsp;<asp:TextBox style="font-size:160%" type="password" id="password" runat="server"></asp:TextBox></td></tr>
       <tr><td> <asp:Button   class="center" style="margin-left:155px;  font-size:130%; " text="Login" width="20%" OnClick="Button1_Click" CssClass="button" runat="server" ID="login_button"></asp:Button></td></tr>
        <tr><td> <asp:Label runat="server" Text="" ID="label1"></asp:Label></td></tr>
    </table>
   <img src="img/skategifs.gif" width="30%" class="center"  />
</asp:Content>

