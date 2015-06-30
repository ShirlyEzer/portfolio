<%--
  Created by IntelliJ IDEA.
  User: Shirly and Oreyan
  Date: 08/05/2015
  Time: 00:27
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ include file="header.jsp"%>
<!DOCTYPE html>
<html>
<head>
  <script type="text/javascript">
    $(document).ready(function () {
              $('#startDate').datetimepicker(({ dateFormat: 'dd-mm-yy' })).val();
              $('#endDate').datetimepicker(({ dateFormat: 'dd-mm-yy' })).val();
            }
    );

    function addAlarm() {
      var name = document.getElementById("name").value;
      var description = document.getElementById("description").value;
      var time = document.getElementById("startDate").value;
      window.alarmSenderProp.addAlarmPerToDoItem(name,description,time);
    }
  </script>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>
    Login
  </title>
</head>
<body>
<div data-theme="a" data-role="page" id="addtodoitem">
  <div data-theme="a" data-role="header">
    <div>
      <a data-role="button" data-rel="back" data-transition="fade" data-theme="a" href="/doitsimple/todo_item_manager" data-icon="back" data-iconpos="right">
        Back
      </a>
      </br>
    </div>
    </br>
    <h3>
      Add Item
    </h3>
  </div>
  <div data-theme="a" data-role="content">
    <form action="/doitsimple/add_todo_item" method="GET" onSubmit="return addAlarm();">
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
        <input type="text" name="startDate" id="startDate" readonly/>
      </div>
      <br>
      <div data-role="fieldcontain">
        <label for="name">End date and time: </label>
        <input type="text" name="endDate" id="endDate" readonly/>
      </div>
      </br>
      <div data-role="fieldcontain">
        <label for="name">Place: </label>
        <input type="text" name="place" id="place"/>
      </div>
      </br>
      <input class="ui-btn" type="submit" value="Add To Do Item">
    </form>
  </div>
</div>
</body>
</html>

