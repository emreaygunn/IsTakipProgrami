<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Calisanlar.aspx.cs" Inherits="IsTakipProgramı.Calisanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblKullaniciYetki" runat="server" Text="">
        <div class="alert alert-error">        
            <button type="button" class="close" data-dismiss="alert">×</button>
            <strong>Bu işlem için yetkiniz bulunmamaktadır!</strong>            
        </div>
    </asp:Label>
    <asp:Panel ID="pnlKullaniciYetki" runat="server">
        <asp:Panel ID="pnlKullaniciEkle" runat="server">
            <div class="row-fluid sortable">
                <div class="box span12">
                    <div class="box-header well" data-original-title>
                        <h2><i class="icon-edit"></i>Kullanıcı Ekle</h2>
                        <div class="box-icon">
                            <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                            <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                            <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>Kullanıcı Bilgilerini Giriniz</legend>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Ad ve Soyad </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtKullaniciAdi" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Telefon</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtTelefon" runat="server" class="span6 typeahead"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">E-Posta</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEPosta" runat="server" class="span6 typeahead"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Sifre</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtSifre" runat="server" class="span6 typeahead"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="selectError3">Departman</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDepartman" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="selectError3">Kullanıcı Yetkisi</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlYetki" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="fileInput">Resim</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="fuResim" runat="server" /><asp:Label ID="lblEskiGorsel" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
                                    <asp:Label ID="lblDurum" runat="server" Text=""></asp:Label>
                                </div>
                            </fieldset>
                        </div>

                    </div>
                </div>
                <!--/span-->
            </div>
        </asp:Panel>

        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header well" data-original-title>
                    <h2><i class="icon-user"></i>Kullanıcılar</h2>
                    <div class="box-icon">
                        <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                        <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>Fotoğraf</th>
                                <th>Ad Soyad</th>
                                <th>Departman</th>
                                <th>E-Posta</th>
                                <th>Telefon</th>
                                <th>Durum</th>
                                <th>İşlem</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptCalisanlar" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <img src='../Uploads/Calisanlar/<%#Eval("Gorsel") %>' width="50px" onerror="this.src='img/no_image.png'" /></td>
                                        <td class="center"><%#Eval("KullaniciAdi") %></td>
                                        <td class="center"><%#Eval("DepartmanAdi") %></td>
                                        <td class="center"><%#Eval("EPosta") %></td>
                                        <td class="center"><%#Eval("Telefon") %></td>
                                        <td class="center"><span class="<%# DurumKontrol(Eval("Aktif").ToString()) %>"><%#Eval("Aktif").ToString()=="1"?"Aktif":"Pasif" %></span></td>
                                        <td class="center">
                                            <a class="btn btn-warning" href="Calisanlar.aspx?id=<%#Eval("KullaniciID") %>">
                                                <i class="icon-edit icon-white"></i>
                                                Düzelt                                            
                                            </a>
                                            <a class="<%# AktifKontrol(Eval("Aktif").ToString(),"1") %>" href="Calisanlar.aspx?s=<%#Eval("KullaniciID") %>">
                                                <i class="<%# AktifKontrol(Eval("Aktif").ToString(),"2") %> icon-white"></i>
                                                <%#Eval("Aktif").ToString()=="1"?"Sil":"Aktif Et" %>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->
        </div>
    </asp:Panel>
</asp:Content>
