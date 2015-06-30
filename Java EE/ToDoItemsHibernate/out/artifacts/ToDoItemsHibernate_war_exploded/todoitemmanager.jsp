<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 06/04/2015
  Time: 23:56
--%>
<%@ page import="java.util.List" %>
<%@ page import="il.ac.hit.model.ToDoItem" %>
<%@include file="header.jsp"%>
<%@ taglib prefix="myDisplayListTag" uri="/WEB-INF/todoitemslist.tld" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>
        DIS Manager
    </title>
</head>
<body>

<!-- Manager -->
<div data-theme="a" data-role="page" id="manager">
    <div data-theme="a" data-role="header">
        <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/doitsimple/homepage" data-icon="back" data-iconpos="right">
            Back
        </a>
        <br/>
        <h3>
            DIS - Do It Simple Manager
        </h3>
    </div>
    <div data-theme="a" data-role="content" data-iconpos="left">
        <div data-theme="a" data-role="header">
            <a data-role="button" href="/doitsimple/add_attempt" data-theme="" data-icon="" data-ajax="false">
                Add to do item
            </a>
            <br/>
            <br/>
            <div data-theme="a" data-role="main" class="ui-content">
                <div data-theme="a" data-role="collapsibleset">
                    <myDisplayListTag:displaylist isExpired="true" />
                </div>
            </div>
        </div>
        <br/>
        <br/>
    </div>
</div>
</body>
</html>