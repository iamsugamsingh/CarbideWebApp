<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Create_Carbide_Enquiry._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />

    <div class="split left">
        <div class="centered">
            <h1>Carbide</h1>
            Carbide is a compound composed of carbon and a less electronegative element. Carbides can be generally classified by the chemical bonds type as follows: (i) salt-like, (ii) covalent compounds, (iii) interstitial compounds, and (iv) "intermediate" transition metal carbides.
            Examples include calcium carbide (CaC2), silicon carbide (SiC), tungsten carbide (WC; often called, simply, carbide when referring to machine tooling), and cementite (Fe3C),[1] each used in key industrial applications. The naming of ionic carbides is not systematic.       
        </div>
    </div>

    <div class="split right">
        <div class="centered">
            <div class="row">
                <div class="col-md-4">
                    <p>
                        <a style="width: 150px; height: 45px;" class="btn btn-default btn-lg" href="loginPage">&nbsp;Enquiry                         
                            <span class="glyphicon glyphicon-send"></span>
                        </a>
                    </p>
                </div>            
            </div> 
            <div class="row">  
                <div class="col-md-4">
                    <p>
                        <a style="width: 150px; height: 45px;" class="btn btn-default btn-lg" href="carbideOrder">  Order &nbsp;&nbsp;
                            <span class="glyphicon glyphicon-send"></span>
                        </a>
                    </p>
                </div>
            </div>
            <div class="row">  
                <div class="col-md-4">
                    <p>
                        <a style="width: 150px; height: 45px;" class="btn btn-default btn-lg" href="receiveOrder">&nbsp;Receive
                            <span class="glyphicon glyphicon-send"></span>
                        </a>
                    </p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
