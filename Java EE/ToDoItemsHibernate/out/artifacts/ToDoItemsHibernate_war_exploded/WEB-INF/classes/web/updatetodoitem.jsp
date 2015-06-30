<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 07/04/2015
  Time: 23:35
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ include file="header.jsp"%>
<!DOCTYPE html>
<html>
<head>
    <script type="text/javascript">
        $(document).ready(function () {
                    $('#startDateU').datetimepicker(({ dateFormat: 'dd-mm-yy' })).val();
                    $('#endDateU').datetimepicker(({ dateFormat: 'dd-mm-yy' })).val();
                }
        );

        function loadItemInfo() {
            document.getElementById("name").value = '${name}';
            document.getElementById("description").value = '${description}';
            document.getElementById("startDateU").value = '${startDate}';
            document.getElementById("endDateU").value = '${endDate}';
            document.getElementById("place").value = '${place}';
        };
    </script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>
        Update To Do Item
    </title>
</head>
<body>
<!-- Update To Do Item -->
<div data-role="page" id="updatetodoitem">
    <div data-theme="a" data-role="header">
        <div>
            <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/doitsimple/todo_item_manager" data-icon="back" data-iconpos="right">
                Back
            </a>
            </br>
        </div>
        </br>
        <h3>
            Update Item
        </h3>
    </div>
    <div data-theme="a" data-role="content">
        <button type="button" onclick="loadItemInfo()">Load Item Info</button>
        <form action="/doitsimple/update_todo_item" METHOD="get">
            <div data-role="fieldcontain">
                <label for="name">Title: </label>
                <input type="text" name="name" id="name" />
            </div>
            </br>
            <div data-role="fieldcontain">
                <label for="name">Description: </label>
                <textarea name="description" id="description"></textarea>
            </div>
            </br>
            <div data-role="fieldcontain">
                <label for="name">Start date and time: </label>
                <input type="text" name="startDateU" id="startDateU" readonly/>
            </div>
            <br>
            <div data-role="fieldcontain">
                <label for="name">End date and time: </label>
                <input type="text" name="endDateU" id="endDateU" readonly/>
            </div>
            </br>
            <div data-role="fieldcontain">
                <label for="name">Place: </label>
                <input type="text" name="place" id="place"/>
            </div>
            </br>
            <input class="ui-btn" type="submit" value="Update Item!">
        </form>
    </div>
</div>
</div>
</body>
</html>
