package il.ac.hit.currencies;

import java.util.List;

/**
 * {@code ICurrencyUpdater} defines the interface for objects that can update their data of currencies.
 *
 * @author Shirly
 * @author Oreyan
 */
public interface ICurrencyUpdater {

    /**
     * A method that updates the component which holds the data of currencies according to list given.
     *
     * @param currencyList an updated list of coins
     */
    public abstract void updateCurrencyData(List<Currency> currencyList);
}
