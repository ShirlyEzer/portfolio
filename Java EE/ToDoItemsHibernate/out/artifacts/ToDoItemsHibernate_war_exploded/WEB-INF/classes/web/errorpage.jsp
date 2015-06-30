<%--
  Created by IntelliJ IDEA.
  User: User
  Date: 21/04/2015
  Time: 20:40
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" isErrorPage="true" %>
<%@include file="header.jsp"%>
<html>
<head>
  <title>Error</title>
</head>
<body>
<div data-theme="a" data-role="header">
  <div>
    <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/homepage.jsp" data-icon="back" data-iconpos="right">
      Back
    </a>
  </div>
  </br>
<% final String errorMessage = (String)request.getAttribute("ErrorMessage"); %>


<h1>An Error Occurred...</h1>

<p>



  <%= errorMessage %><br><br>





</p>
</div>
</body>
</html>
