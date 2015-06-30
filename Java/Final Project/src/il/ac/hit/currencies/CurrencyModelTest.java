package il.ac.hit.currencies;

import junit.framework.TestCase;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;

public class CurrencyModelTest extends TestCase {
    CurrencyModel currencyModel = new CurrencyModel(null);

    /**
     * @throws java.lang.Exception
     */
    @Before
    public void setUp() throws Exception {

    }

    /**
     * @throws java.lang.Exception
     */
    @After
    public void tearDown() throws Exception {

    }

    /**
     * Test method for {@link il.ac.hit.currencies.CurrencyModel#convert(double,String,String)}.
     * @throws java.lang.Exception
     */
    @Test
    public void testConvert() throws Exception {
        assert(currencyModel.convert(5.0,"Israel NIS","Israel NIS") == 5.0);
    }

    /**
     * Test method for {@link il.ac.hit.currencies.CurrencyModel#getCurrenciesData()}.
     * @throws java.lang.Exception
     */
    @Test
    public void testGetCurrenciesData() throws Exception {
        assert (currencyModel.getCurrenciesData() != null && currencyModel.getCurrenciesData().size() > 0);
    }
}