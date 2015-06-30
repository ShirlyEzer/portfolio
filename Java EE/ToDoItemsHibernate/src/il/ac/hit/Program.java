package il.ac.hit;

import java.io.FileInputStream;
import java.sql.*;
import java.util.*;
import il.ac.hit.model.*;

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Created by User on 04/04/2015.
 */
public class Program {

/*
    public static void main(String[] args) {

        IToDoItemsDAO toDoItemHibernateDAO = HibernateToDoItemsDAO.getInstance();
        Calendar calendar = Calendar.getInstance();
        calendar.set(1990,12,1,12,03);
        Date date = calendar.getTime();
        System.out.print(date);
        try {
            //if(toDoItemHibernateDAO.addNewUserAndPassword("Shirly", "1234"))
            //{
            //    System.out.println("user Shirly added");
            //}


            toDoItemHibernateDAO.addToDoItem(new ToDoItem(1, "n1", "d1",date , new Date(),new Date(), "p1",1));
            System.out.println("1 added");
            toDoItemHibernateDAO.addToDoItem(new ToDoItem(2, "n2", "d2",date , new Date(),new Date(), "p2", 1));
            System.out.println("2 added");
            toDoItemHibernateDAO.addToDoItem(new ToDoItem(3, "n3", "d3",date , new Date(),new Date(), "p3", 1));
            System.out.println("3 added");

        } catch (ToDoItemsPlatformException e) {
            e.printStackTrace();
        }
    }
    */
/*
    public static void main(String[] args) {
        Program p = new Program();
        try {
            p.createConnection();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        p.runSqlStatement();
    }

    public Connection createConnection() throws IOException, ClassNotFoundException, SQLException {

        Connection connection;

        Properties prop = new Properties();
        System.out.println("test");
        prop.load(new FileInputStream(System.getProperty("/hibernate.cfg")));
        System.out.println("user.home: "+System.getProperty("user.home"));
        String host = prop.getProperty("host").toString();
        String username = prop.getProperty("username").toString();
        String password = prop.getProperty("password").toString();
        String driver = prop.getProperty("driver").toString();

        System.out.println("host: " + host + "\\username: " + username + "\\password: " + password + "\ndriver: " + driver);

        Class.forName(driver);
        System.out.println("--------------------------");
        System.out.println("DRIVER: " + driver);
        connection = DriverManager.getConnection(host, username, password);
        System.out.println("CONNECTION: " + connection);

        return connection;
    }

    public void runSqlStatement() {
        try {
            String createTable = "CREATE TABLE `example` (id INT, data VARCHAR(100))";
            Statement statement = createConnection().createStatement();
            boolean rs = statement.execute(createTable);

        } catch (IOException ex) {
            Logger.getLogger(Program.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(Program.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }*/
}
