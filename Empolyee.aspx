<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Empolyee.aspx.cs" Inherits="Food_Menu.Empolyee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name: </td>
            <td><asp:TextBox ID="textname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Cource: </td>
            <td><asp:DropDownList ID="ddlcource" runat="server" OnSelectedIndexChanged="ddlcource_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Branch: </td>
            <td><asp:DropDownList ID="ddlbranch" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btninsert" runat="server" Text="INSERT" OnClick="btninsert_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gvemploye" runat="server" AutoGenerateColumns="False" OnRowCommand="gvemploye_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <%#Eval("dit") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cource ">
                            <ItemTemplate>
                                <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch ">
                            <ItemTemplate>
                                <%#Eval("bname") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="dlt" CommandArgument='<%#Eval("dit") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" CommandArgument='<%#Eval("dit") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>

    </table>
</asp:Content>
