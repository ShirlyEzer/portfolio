<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 06/04/2015
  Time: 13:56
--%>
<%@ page import="il.ac.hit.model.User" %>
<%@include file="header.jsp"%>
<%@ taglib prefix="myLoginLogoutTag" uri="/WEB-INF/loginlogoutld.tld" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>
        Home Page
    </title>
</head>
<body>

<!-- Home -->
<div data-theme="a" data-role="page" id="homepage">
    <div data-theme="a" data-role="header">
        <h1>
            DIS - Do It Simple App
        </h1>
        <br>
        <div data-role="navbar">
            <a href="/doitsimple/todo_item_manager" data-theme="a"  data-icon="" data-ajax="false" data-pos="left">
                DIS - Do It Simple Manager
            </a>
            <a href="/doitsimple/login" data-theme="a" data-icon="" data-ajax="false" data-pos="right">
                <myLoginLogoutTag:loginlogout/>
            </a>
            </br>
            </br>
        </div>
    </div>
    <div data-theme="a" data-role="content">
        <div class="picture1" id="picture" />
        </br>
        </br>
    </div>
    <div data-theme="a" data-role="footer">
        <h2>
            To Do Items Application
        </h2>
        <p>
            <b>
                <strong>
                    This to-do list management application developed by Shirly&Oreyan
                    as part of a course in java EE at HIT.
                </strong>
            </b>
        </p>
    </div>
</div>
</body>
</html>
