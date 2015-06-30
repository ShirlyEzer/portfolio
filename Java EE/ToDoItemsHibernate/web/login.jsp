<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 06/04/2015
  Time: 14:34
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" import="java.awt.event.ActionEvent,il.ac.hit.model.User" %>
<%@include file="header.jsp"%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <title>
    Login
  </title>
</head>
<body>
<div data-theme="a" data-role="page">
  <div data-theme="a" data-role="header">
    <div>
      <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/doitsimple/homepage" data-icon="back" data-iconpos="right">
        Back
      </a>
    </div>
    </br>
    </br>
    <h1> Login to DIS - Do It Simple :)</h1>
    </br>
  </div>
  <div data-theme="a" data-role="content">
    <form ACTION="/doitsimple/login_attempt" METHOD="GET">
      <div data-role="fieldcontain">
        <label for="user">User Name:</label>
        <input type="text" name="user" id="user" />
      </div>
      </br>
      <div data-role="fieldcontain">
        <label for="user">Password:</label>
        <input type="password" id="pass" name="pass" />
      </div>
      </br>
      <input class="ui-btn" type="submit" id="Login" value="Login!" />
      </br>
    </form>
    <a data-role="button" href="/doitsimple/create_account">Create new account</a>
  </div>
</div>
</div>
</body>
</html>
