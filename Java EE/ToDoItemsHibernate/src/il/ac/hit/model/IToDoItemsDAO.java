package il.ac.hit.model;

import java.util.List;

/**
 * Created by User on 04/04/2015.
 */
public interface IToDoItemsDAO {

    public boolean addToDoItem(ToDoItem ob) throws ToDoItemsPlatformException;
    public ToDoItem getToDoItem(int id) throws ToDoItemsPlatformException;
    public void deleteToDoItem(int id) throws ToDoItemsPlatformException;
    public List<ToDoItem> getToDoItems(User user) throws ToDoItemsPlatformException;
    public void updateToDoItem(int id, ToDoItem coupon) throws ToDoItemsPlatformException;

    public boolean addNewUserAndPassword(String user, String pass) throws ToDoItemsPlatformException;
    public User checkUserAndPassword(String user, String pass) throws ToDoItemsPlatformException;
    public User getUser(String user) throws ToDoItemsPlatformException;
}
