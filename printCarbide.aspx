<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printCarbide.aspx.cs" Inherits="CarbideWebApp.printCarbide" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Carbide Master</title>
    <link href="Styles/Site.css" rel="stylesheet" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="images/ANU%20LOGO.jpg" rel="icon" type="image/png" />
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
            <a class="navbar-brand" href="index.aspx" style="font-size:20px; font-weight:bold; margin-left:90px;">CarbideWebApp</a>
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
                <li><a href="carbideEnquiry.aspx?location=1">AWS-1</a></li>
                <li><a href="carbideEnquiry.aspx?location=2">AWS-2</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
    <form id="form1" runat="server">
      <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <div>
        <div style="text-align:left">
    <b><asp:Label ID="Label4" runat="server"  Text="Label" style="font-size: large"></asp:Label></b>
    </div>
    <br>
        <h2 style="text-align:center; color:rosybrown;">FINAL DIMENSION</h2>
        <p style="text-align:center;">Form No. AWS/TCS/F-02,Rev No-01</p>
    <br />
    <table style="margin: 0px auto;">
        <tr >
            <td>
               <b><asp:Label ID="offerDate" runat="server" Text="Offer Date"></asp:Label></b> &nbsp;&nbsp;
            </td>
            <td>
                <b><asp:Label ID="offerInq" runat="server" Text="Offer Inq."></asp:Label></b> &nbsp;&nbsp;
            </td>
            <td>
                <b><asp:Label ID="deliveryDate" runat="server" Text="Delivery Date"></asp:Label></b> &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="offerDateTxtbox"  class="form-control" runat="server" Width="150px" style="text-align: center;margin-right:10px"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="offerInqTxtbox"  runat="server" class="form-control" Width="100px" style="text-align: center;margin-right:10px"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="deliveryDateTxtbox"  runat="server" class="form-control" Width="150px" style="text-align: center;margin-right:10px"></asp:TextBox>&nbsp;&nbsp;
            </td>            
            <td>
                <asp:DropDownList ID="DropDownList1" style="margin-right:10px; width:150px;" class="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    
                </asp:DropDownList>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="print" style="margin-right:10px; margin-top:-20px;" runat="server" Text="Print" class="btn btn-primary" OnClick="print_Click" Width="80px"/>
            </td>
            <td>
                <asp:Button ID="export" style="margin-right:10px; margin-top:-20px;" runat="server" Text="Export" class="btn btn-primary" OnClick="Export_Click" Width="80px"/>
            </td>
            <td>
                <asp:Button ID="placeOrderBtn" style="margin-right:10px; margin-top:-20px;" 
                    runat="server" class="btn btn-primary" Text="Place Order"  Width="100px" 
                    OnClick="placeOrderBtn_Click" Visible="False"/>
            </td>
        </tr>
    </table>
    <br />
    
        <div class="container-fluid">
            <asp:GridView ID="GridView1" runat="server" class="table table-sm" AutoGenerateColumns="false" HorizontalAlign="Center" Width="100%" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White">
                <Columns>
                    <asp:BoundField DataField="PinOrd" HeaderText="PT"  />
                    <asp:BoundField DataField="NumOrd" HeaderText="UID"  />
                    <asp:BoundField DataField="CodPie" HeaderText="Part"/>
                    <asp:BoundField DataField="DiaExt" HeaderText="OD" />
                    <asp:BoundField DataField="Longit" HeaderText="Length"/>
                    <asp:BoundField DataField="DiaInt" HeaderText="ID"/>
                    <asp:BoundField DataField="CalPie" HeaderText="Grade"/>
                    <asp:BoundField DataField="TotPie" HeaderText="Qty"/>
                    <asp:BoundField DataField="Datos"  HeaderText="Remarks" ReadOnly="true" />
                    <asp:BoundField DataField="EntOrd" HeaderText="Delivery Date" DataFormatString="{0:dd/MMM/yyyy}" ReadOnly="True"/>
                    <asp:BoundField DataField="Vendor" HeaderText="Vendor"/>
                     <%--<asp:TemplateField HeaderText="Vendor">
                        <ItemTemplate>
                            <asp:Label ID="ven" runat="server" Text='<%#Bind("Vendor")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>



     <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
