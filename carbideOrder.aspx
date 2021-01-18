<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carbideOrder.aspx.cs" Inherits="CarbideWebApp.carbideOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Carbide Master</title>
    <link href="Styles/Site.css" rel="stylesheet" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="images/ANU%20LOGO.jpg" rel="icon" type="image/png" />
    <style>
        .navbar
        {
            background:#3390ff;
            border-radius:0px;
            box-shadow:2px 2px 5px black;
        }
            
        .navbar-brand, .navbar-brand:hover
        {
            color:White;
        }
        
        .nav > li >a, .nav > li >a:hover
        {
            color:White;
            background:#3390ff;
        }
    </style>


</head>
<body>
    
    <nav class="navbar navbar">
        <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#" style="font-size:20px; font-weight:bold; margin-left:90px;">Carbide Master</a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">            
            <ul class="nav navbar-nav navbar-right" style="margin-right:90px; font-size:16px; font-weight:bold;">
                <li><a href="index.aspx">Home</a></li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Enquiry <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="carbideEnquiry.aspx?location=1">AWS-1</a></li>
                        <li><a href="carbideEnquiry.aspx?location=2">AWS-2</a></li>
                    </ul>
                </li>
                <li><a href="carbideOrder.aspx">Order</a></li>
                <li><a href="carbideReceive.aspx">Receive</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <h2 style="text-align: center; color: rosybrown;">Order Carbide</h2>
    <br />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
        <script type = "text/javascript" >
            history.pushState(null, null, location.href);
            window.onpopstate = function () {
                history.go(1);
            };
    </script>
    <div>
        <table style="margin: 0px auto;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Order"></asp:Label>&nbsp;&nbsp;
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Style="text-align: center" Width="100px" required></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" Style="text-align: center" Width="100px" required></asp:TextBox>&nbsp;&nbsp;
                </td>
                <%--<td>
                    <asp:Button ID="Button4" Width="100px" runat="server" Text="View" />&nbsp;&nbsp;
                </td>--%>
                <td>
                    <asp:Button ID="Button5" Width="100px" class="btn btn-primary" style="margin-top:-25px" runat="server" Text="Print" OnClick="Button5_Click" />&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button6" Width="100px" class="btn btn-success" style="margin-top:-25px" runat="server" Text="Save" OnClick="Button6_Click" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Inquiry No."></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Vendor"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Vendor Name"></asp:Label>&nbsp;&nbsp;
                </td>
                <!--
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Currency" ></asp:Label>&nbsp;&nbsp;
                </td>
                -->
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Delivery Date"></asp:Label>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td> 
                    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right:10px;" class="form-control" Width="140px" AutoPostBack="true" required OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" style="margin-right:10px;" class="form-control" Width="140px" AutoPostBack="true" required OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="240px" class="form-control" Style="text-align: center; width:200px; margin-right:10px;" required></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100px" class="form-control" Style="text-align: center; width:150px" OnTextChanged="TextBox4_TextChanged" required PlaceHolder="DD-MM-YYYY"></asp:TextBox>&nbsp;&nbsp;
                </td>
                
                <!--
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100px" Style="text-align: center"></asp:TextBox>&nbsp;&nbsp;
                </td>
                -->
            </tr>
        </table>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox4" Format="dd-MMM-yyyy"/>
    </div>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" class="table table-sm" HorizontalAlign="Center" Width="75%" AutoGenerateColumns="true">
        <%--<Columns>
            <asp:BoundField DataField="NumOrd" HeaderText="UID" ItemStyle-Width="150" />
            <asp:BoundField DataField="CodPie" HeaderText="Element" ItemStyle-Width="150" />
            <asp:BoundField DataField="TotPie" HeaderText="Total" ItemStyle-Width="150" />
            <asp:BoundField DataField="CodArt" HeaderText="Article Number" ItemStyle-Width="150" />
        </Columns>--%>
        
        <HeaderStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>

    </form>


     <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
