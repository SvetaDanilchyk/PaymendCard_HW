using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverDevBy
{
    public abstract class Constans
    {
        //initialize
        public const string VACANCIES_PAGE_XPATH = "//a[@class='navbar__nav-item navbar__nav-item_label']";

        //header vacancies with count
        public const string NUMBER_OF_VACANCIES_XPATH = "//h2[@class ='informer__title']";
        public const string NUMBER_VACANCIES = "//a[@class = 'navbar__nav-item navbar__nav-item_label' and text() = 'Вакансии']";

        //close info window button
        public const string CLOSE_BUTTON_XPATH = "//button[@class = 'wishes-popup__button-close wishes-popup__button-close_icon']";//= 'submit'

        //vacancies of collection
        public const string VACANCIES_COLLECTIONS_XPATH = "//label[@class='collection_radio_buttons']";

        //header vacancies and quantity on the vacancies page
        public const string HEADER_VACANCIES_AND_QUANTITY = "//h1[@class='vacancies-list__header-title']";

        //span vacancies on the  vacancies page
        public const string NAME_VACANCIES = "//span[@class='vacancies-list__filter-tag__text']";

    }
}
