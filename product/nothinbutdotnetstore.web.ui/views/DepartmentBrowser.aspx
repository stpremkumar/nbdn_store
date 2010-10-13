<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
		<!-- for each of the main departments in the store -->
		    <%
	      var items = (IEnumerable<DepartmentItem>)	this.Context.Items["blah"];

          foreach (var department_item in items)
          {

%>
        	<tr class="ListItem">
               		 <td>                     
      <%= department_item.name %>
                	</td>
           	 </tr>        
           	 <%
          }%>
	    </table>            
</asp:Content>
