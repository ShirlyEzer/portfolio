package il.ac.hit.currencies;

import java.util.List;

/**
 * {@code ICurrencyModel} defines the interface for objects that can get the data of currencies
 * and convert amount of money from source currency to target currency.
 *
 * @author Shirly
 * @author Oreyan
 */
public interface ICurrencyModel {

    /**
     * A method which returns a list of currencies.
     *
     * @return list of currencies
     * @exception il.ac.hit.currencies.CurrenciesPlatformException if the currencies data is not available
     * @throws il.ac.hit.currencies.CurrenciesPlatformException
     */
    public List<Currency> getCurrenciesData() throws CurrenciesPlatformException;

    /**
     * A method which convert amount of money from a source currency to a destination currency rate.
     *
     * @param sum amount of money for the conversion.
     * @param sourceCoin describes the source coin
     * @param destinationCoin describes the destination coin
     *
     * @return amount of money after conversion
     * @exception il.ac.hit.currencies.CurrenciesPlatformException if the currencies data is not available
     * @throws il.ac.hit.currencies.CurrenciesPlatformException
     */
    public abstract double convert(double sum, String sourceCoin, String destinationCoin)
            throws CurrenciesPlatformException;

    /**
     * A method which returns the last update date
     *
     * @return string represents the update date
     */
    public String getLastUpdate();
}
