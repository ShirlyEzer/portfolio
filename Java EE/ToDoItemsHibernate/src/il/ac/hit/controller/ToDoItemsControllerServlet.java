package il.ac.hit.controller;

import java.io.IOException;
import java.io.PrintWriter;
import java.io.Writer;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;
import javax.servlet.*;

import il.ac.hit.model.*;

/**
 * Created by User on 13/04/2015.
 */
@WebServlet(name = "controller", urlPatterns = {"/doitsimple/*"})
public class ToDoItemsControllerServlet extends HttpServlet {

    private static final long serialVersionUID = 1L;
    private IToDoItemsDAO hibernateToDoItemsDAO = null;

    public ToDoItemsControllerServlet() {
        hibernateToDoItemsDAO = HibernateToDoItemsDAO.getInstance();
        System.out.printf("in controller servlet\n");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String path = request.getPathInfo();

        switch (path) {
            case "/homepage":
                homePage(request,response);
                break;
            case "/login":
                login(request,response);
                break;
            case "/login_attempt":
                loginAttempt(request,response);
                break;
            case "/add_todo_item":
                addToDoItem(request, response);
                break;
            case "/add_attempt":
                addAttempt(request, response);
                break;
            case "/update_todo_item":
                updateToDoItem(request,response);
                break;
            case "/update_attempt":
                updateAttempt(request, response);
                break;
            case "/delete_todo_item":
                deleteToDoItem(request,response);
                break;
            case "/todo_item_manager":
                toDoItemManager(request,response);
                break;
            case "/new_account":
                newAccount(request,response);
                break;
            case "/create_account":
                createAccount(request,response);
                break;
            case "/test":
                break;
            default:
                defaultCase(request,response);
        }
    }

    private void homePage(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for homepage web page\n");
        forwardPage(request, response, "homepage.jsp");
    }

    private void login(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for login web page\n");
        HttpSession session = request.getSession();
        User user = (User) session.getAttribute("user");
        if (user == null) {
            forwardPage(request, response, "login.jsp");
        } else {
            if (user.isLoggedIn() == false) {
                forwardPage(request, response, "login.jsp");
            } else {
                user.setLoggedIn(false);
                forwardPage(request, response, "homepage.jsp");
            }
        }
    }

    private void addAttempt(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for add page\n");
        forwardPage(request, response, "addtodoitem.jsp");
    }

    private void addToDoItem(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for add to do item\n");
        String startDate = request.getParameter("startDate");
        String endDate = request.getParameter("endDate");
        String name = request.getParameter("name");
        String description = request.getParameter("description");
        String place = request.getParameter("place");
        User user = (User) request.getSession().getAttribute("user");
        Date start = ParseStringToDate(startDate);
        Date end = ParseStringToDate(endDate);
        ToDoItem toDoItem = new ToDoItem(0, name, description, start, end, new Date(), place, user.getId());
        try {
            hibernateToDoItemsDAO.addToDoItem(toDoItem);
            List<ToDoItem> itemList = hibernateToDoItemsDAO.getToDoItems(user);
            request.getSession().setAttribute("todoitems", itemList);
        } catch (ToDoItemsPlatformException e) {
            e.printStackTrace();
        }

        forwardPage(request, response,"todoitemmanager.jsp");
    }

    private void updateToDoItem(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for update to do item\n");
        String startDate = request.getParameter("startDateU");
        String endDate = request.getParameter("endDateU");
        String name = request.getParameter("name");
        String description = request.getParameter("description");
        String place = request.getParameter("place");
        int idToDoItem = (Integer) request.getSession().getAttribute("id");
        User user = (User) request.getSession().getAttribute("user");

        try {
            hibernateToDoItemsDAO.updateToDoItem(idToDoItem, new ToDoItem(idToDoItem, name, description, ParseStringToDate(startDate), ParseStringToDate(endDate), null, place, user.getId()));
            List<ToDoItem> itemList = hibernateToDoItemsDAO.getToDoItems(user);
            request.getSession().setAttribute("todoitems", itemList);
        } catch (ToDoItemsPlatformException e) {
            e.printStackTrace();
        }
        forwardPage(request, response, "todoitemmanager.jsp");
    }

    private void deleteToDoItem(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for delete to do item\n");
        int idToDoItem = Integer.parseInt(request.getParameter("did"));
        User user = (User) request.getSession().getAttribute("user");
        try {
            hibernateToDoItemsDAO.deleteToDoItem(idToDoItem);
            List<ToDoItem> itemList = hibernateToDoItemsDAO.getToDoItems(user);
            request.getSession().setAttribute("todoitems", itemList);
        } catch (ToDoItemsPlatformException e) {
            e.printStackTrace();
        }
        forwardPage(request, response, "todoitemmanager.jsp");
    }

    private void updateAttempt(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for update id");
        String idString = request.getParameter("uid");
        int idToDoItem = Integer.parseInt(idString);
        try {
            ToDoItem item = hibernateToDoItemsDAO.getToDoItem(idToDoItem);
            request.setAttribute("name",item.getName());
            request.setAttribute("description",item.getDescription());
            request.setAttribute("startDate",item.getStartDate());
            request.setAttribute("endDate",item.getEndDate());
            request.setAttribute("place",item.getPlace());
        } catch (ToDoItemsPlatformException e) {
            e.printStackTrace();
        }
        request.getSession().setAttribute("id", idToDoItem);
        forwardPage(request, response, "updatetodoitem.jsp");
    }

    private void createAccount(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for the page create new account web page\n");
        forwardPage(request, response,"createaccount.jsp");
    }

    private void toDoItemManager(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("request for app manager web page\n");
        HttpSession session = request.getSession();
        User user = (User) session.getAttribute("user");
        if (user == null) {
            System.out.println("user not attach to the session\n");
            request.setAttribute("ErrorMessage", "Must login first");
            forwardPage(request, response, "errorpage.jsp");
        } else {
            if (user.isLoggedIn()) {
                System.out.println("user " + user.getUserName() + " logged in to the app\n");
                System.out.print("in manager\n");
                try {
                    List<ToDoItem> itemList = hibernateToDoItemsDAO.getToDoItems(user);
                    session.setAttribute("todoitems", itemList);
                    forwardPage(request, response,"todoitemmanager.jsp");
                } catch (ToDoItemsPlatformException e) {
                    e.printStackTrace();
                }
            } else {
                System.out.println("user " + user.getUserName() + " not logged in\n");
                request.setAttribute("ErrorMessage", "user " + user.getUserName() + " not logged in");
                forwardPage(request, response,"errorpage.jsp");
            }
        }
    }

    private void newAccount(HttpServletRequest request, HttpServletResponse response) {
        HttpSession session = null;
        User user = null;
        System.out.println("request for creating the new account\n");
        String userName = request.getParameter("user");
        String password = request.getParameter("pass");
        if (userName == "" || password == "") {
            System.out.println("Not all parameters are initialized\n");
            request.setAttribute("ErrorMessage", "Not all parameters are initialized");
            forwardPage(request, response, "errorpage.jsp");
        } else {
            try {
                System.out.println("Parameters are initialized" + userName + " " + password + "\n");
                if (hibernateToDoItemsDAO.addNewUserAndPassword(userName, password)) {
                    session = request.getSession();
                    user = hibernateToDoItemsDAO.getUser(userName);
                    System.out.println("New account created: " + user.getId() + " " + user.getUserName() + " " + user.getPassword() + "\n");
                    session.setAttribute("user", user);
                    forwardPage(request, response, "login.jsp");
                } else {
                    System.out.println("Account was not created: " + userName + " " + password + "\n");
                }
            } catch (ToDoItemsPlatformException e) {
                e.printStackTrace();
            }
        }
    }

    private void loginAttempt(HttpServletRequest request, HttpServletResponse response)  {
        User user = null;
        System.out.println("request for attempting to log in\n");
        String userName = request.getParameter("user");
        String password = request.getParameter("pass");
        if (userName == "" || password == "") {
            System.out.println("Not all parameters are initialized\n");
            request.setAttribute("ErrorMessage", "Not all parameters are initialized");
            forwardPage(request, response, "errorpage.jsp");
        } else {
            System.out.println("Parameters are initialized: " + userName + " " + password);
            try {
                user = hibernateToDoItemsDAO.checkUserAndPassword(userName, password);
            } catch (ToDoItemsPlatformException e) {
                System.out.println("User failed logged in\n");
                request.setAttribute("ErrorMessage", "Password or User Name are not correct");
                forwardPage(request, response, "errorpage.jsp");
                e.printStackTrace();
            }
            System.out.println("User logged in: " + user.getId() + " " + user.getUserName() + " " + user.getPassword() + "\n");
            HttpSession session = request.getSession();
            session.setAttribute("user", user);
            user.setLoggedIn(true);
            forwardPage(request, response, "homepage.jsp");
        }
    }

    private void defaultCase(HttpServletRequest request, HttpServletResponse response) {
        System.out.printf("in default\n");
        request.setAttribute("ErrorMessage", "in default case");
        forwardPage(request,response,"errorpage.jsp");
    }

    private void forwardPage(HttpServletRequest request, HttpServletResponse response, String page)  {
        RequestDispatcher dispatcher = request.getRequestDispatcher("/" + page);
        try {
            dispatcher.forward(request, response);
        } catch (ServletException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private Date ParseStringToDate(String dateString) {
        Date date = null;
        if(dateString != null) {

            DateFormat simpleDate = new SimpleDateFormat("dd-MM-yyyy hh:mm");
            try {
                date = simpleDate.parse(dateString);
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        return date;
    }
}
