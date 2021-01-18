<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="CarbideWebApp.demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript" language="javascript">

           function controlEnter(obj, event) {

               var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

               if (keyCode == 13) {

                   document.getElementById(obj).focus();

                   return false;

               }

               else {

                   return true;

               }

           }

</script>

<body>

    <form id="form1" runat="server">

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

    </form>

</body>
</html>
