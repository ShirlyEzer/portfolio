package il.ac.hit.model;

import java.io.IOException;
import java.lang.Object;
import java.lang.Override;
import java.lang.String;
import java.util.ArrayList;
import java.util.List;

import org.apache.log4j.FileAppender;
import org.apache.log4j.PatternLayout;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;
import org.apache.log4j.Logger;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.Query;


/**
 *
 */
public class HibernateToDoItemsDAO implements IToDoItemsDAO{

    //private static Logger logger = Logger.getLogger(HibernateToDoItemsDAO.class);
    private static HibernateToDoItemsDAO instance;
    private SessionFactory factory;
    private List<String> userNames;

    private HibernateToDoItemsDAO() {
        //try {
            //logger.addAppender(new FileAppender(new PatternLayout("%-5p [%t]: %m%n"),"src\\model_log.txt"));
        //} catch (IOException e) {
         //   e.printStackTrace();
        //}

        //creating factory for getting sessions
        Configuration configuration = new Configuration().configure("hibernate.cfg.xml");

        ServiceRegistry serviceRegistry = new ServiceRegistryBuilder().applySettings(
                configuration.getProperties()).buildServiceRegistry();
        //logger.info("in ctor");
        factory = configuration.buildSessionFactory(serviceRegistry);
        userNames = new ArrayList<String>();
        Session session = null;
        Transaction tx = null;
        String hql = "SELECT U.userName FROM il.ac.hit.model.User U";
        Query query = null;

        try
        {
            session = factory.openSession();
            query = session.createQuery(hql);
            userNames = query.list();
            tx = session.beginTransaction();
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in getting all user names");
                }
            }
        }
    }

    public static HibernateToDoItemsDAO getInstance() {

        if (HibernateToDoItemsDAO.instance == null)
            HibernateToDoItemsDAO.instance = new HibernateToDoItemsDAO();
        return HibernateToDoItemsDAO.instance;
    }

    @Override
    public boolean addToDoItem(ToDoItem ob) throws ToDoItemsPlatformException {
        boolean isAdded = true;
        Session session = null;
        Transaction tx = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            session.save(ob);
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            isAdded = false;
            throw new ToDoItemsPlatformException("Failure in add to do item " + ob.getId(),e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in add to do item " + ob.getId());
                }
            }
        }

        return isAdded;
    }

    @Override
    public ToDoItem getToDoItem(int id) throws ToDoItemsPlatformException {
        ToDoItem toDoItemReturned = null;
        Session session = null;
        Transaction tx = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            toDoItemReturned = (ToDoItem)session.get(ToDoItem.class,id);
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException("Failure in get to do item " + id,e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in get to do item " + id);
                }
            }
        }

        return toDoItemReturned;
    }

    @Override
    public void deleteToDoItem(int id) throws ToDoItemsPlatformException {
        Session session = null;
        Transaction tx = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            ToDoItem toDoItem = (ToDoItem)session.get(ToDoItem.class, id);
            session.delete(toDoItem);
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException("Failure in delete to do item " + id,e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in delete to do item " + id);
                }
            }
        }
    }

    @Override
    public List<ToDoItem> getToDoItems(User user) throws ToDoItemsPlatformException {
        Session session = null;
        Transaction tx = null;
        Query query = null;
        List<ToDoItem> results = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            query = session.createQuery("FROM il.ac.hit.model.ToDoItem I WHERE I.userID = :userID");
            query.setParameter("userID",user.getId());
            results = query.list();
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException("Failure in get all to do items ",e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in get all to do items");
                }
            }
        }
        return results;
    }

    @Override
    public void updateToDoItem(int id, ToDoItem toDoItem) throws ToDoItemsPlatformException {
        Session session = null;
        Transaction tx = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            ToDoItem temp = (ToDoItem)session.get(ToDoItem.class, id);
            temp.setDescription(toDoItem.getDescription());
            temp.setStartDate(toDoItem.getStartDate());
            temp.setEndDate(toDoItem.getEndDate());
            temp.setName(toDoItem.getName());
            temp.setPlace(toDoItem.getPlace());
            session.update(temp);
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException("Failure in update to do item "+id,e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in update to do item "+id);
                }
            }
        }
    }

    @Override
    public boolean addNewUserAndPassword(String user, String pass) throws ToDoItemsPlatformException {
        boolean isAdded = true;
        Session session = null;
        Transaction tx = null;
        Query query = null;
        List<User> results = null;

        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            if(userNames.contains(user))
            {
                String msg = "Failure in adding new user and pass: user name " + user + " already exist";
                throw new ToDoItemsPlatformException(msg,new Throwable());
            }
            else {
                session.save(new User(0,user,pass));
                tx.commit();
            }
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            isAdded = false;
            throw new ToDoItemsPlatformException("Failure in adding new user and pass " + user,e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in adding new user and pass " + user);
                }
            }
        }
        userNames.add(user);
        return isAdded;
    }

    @Override
    public User checkUserAndPassword(String user, String pass) throws ToDoItemsPlatformException {
        String hql = "FROM il.ac.hit.model.User U WHERE U.userName = :userName and U.password = :password";
        Session session = null;
        Transaction tx = null;
        Query query = null;
        List<User> results = null;
        User loggedInUser = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            query = session.createQuery(hql);
            query.setParameter("userName",user);
            query.setParameter("password",pass);
            results = query.list();
            if (results.size() == 1)
            {
                loggedInUser = results.get(0);
            }
            else
            {
                throw new HibernateException("Failure in match user and pass" + user);
            }
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException(e.getMessage(),e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage()+" Failure in match user and pass " + user);
                }
            }
        }
        return loggedInUser;
    }

    @Override
    public User getUser(String user) throws ToDoItemsPlatformException
    {
        String hql = "FROM il.ac.hit.model.User U WHERE U.userName = :userName";
        Session session = null;
        Transaction tx = null;
        Query query = null;
        List<User> results = null;
        User loggedInUser = null;
        try
        {
            session = factory.openSession();
            tx = session.beginTransaction();
            query = session.createQuery(hql);
            query.setParameter("userName",user);
            results = query.list();
            if (results.size() == 1)
            {
                loggedInUser = results.get(0);
            }
            tx.commit();
        }
        catch (HibernateException e)
        {
            if (tx!=null) tx.rollback();
            throw new ToDoItemsPlatformException("Failure in getting user " + user,e);
        }
        finally
        {
            if(session!=null)
            {
                try
                {
                    session.close();
                }
                catch(HibernateException e)
                {
                    //logger.error(e.getMessage());
                }
            }
        }
        return loggedInUser;
    }
}
