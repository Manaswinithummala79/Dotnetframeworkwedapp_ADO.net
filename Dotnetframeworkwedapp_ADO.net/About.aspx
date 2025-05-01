<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Dotnetframeworkwedapp_ADO.net.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.
    </h3>
    <p>Total Number of active users:</p>
    <asp:Label ID="lblTotalCount" runat="server" Text="Label"></asp:Label>

</asp:Content>
