<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 20/04/2015
  Time: 11:29
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java"%>
<%@include file="header.jsp"%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>
    Create New Account
  </title>
</head>
<body>
<div data-theme="a" data-role="page">
  <div data-theme="a" data-role="header">
    <div>
      <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/doitsimple/login" data-icon="back" data-iconpos="right">
        Back
      </a>
    </div>
    </br>
    </br>
    <h1> Create Account - Do It Simple :)</h1>
    </br>
  </div>
  <div data-theme="a" data-role="content">
    <h1> Create new account </h1>
    </br>
    <form action="/doitsimple/new_account" method="GET">
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
      <input class="ui-btn" type="submit" id="Create" value="Create!"/>
    </form>
  </div>
</div>
</body>
</html>