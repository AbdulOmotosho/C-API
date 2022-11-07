using System.Text;
using System.Threadingtasks;
using RestSharp;

namespace Countries
{
    class Program
    {
        static void Main(string[] args) {
            string url = "https://xc-countries-api.herokuapp.com/api/countries";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
        }
        function changeList() {
        const countryOptions = document.getElementById('country-dropdown');
        const selectedIndex = countryOptions.selectedIndex;
        const countryOption = countryOptions.children[selectedIndex];
        console.log(countryOption.innerText, countryOption.getAttribute('value'));
        const countryCode = countryOption.getAttribute('value');
        const promise = fetch(getStateUrl(countryCode), {
            method: 'GET',
            headers: {
            'Content-Type': 'application/json'
            }
        });
        promise.then(response => response.json())
            .then(response => response.sort(compareNames))
            .then(data => { addStateChildren(data) });
        }

        public int compareNames(a, b) {
        var nameA = a.name.toLowerCase(), nameB = b.name.toLowerCase();
        console.log(nameA, nameB)
        if (nameA < nameB) //sort string ascending
            return -1;
        if (nameA > nameB)
            return 1;
        return 0; //default return value (no sorting)
        };
        // returns the names from the data objects in an string array
        public string getData(response) {
        const data = JSON.parse(response);
        console.log(data);
        data.sort(compareNames);
        console.log(data);
        return data;
        }

        //Adds string options
        public string createOptionItem(name, value, ID) {
        let option = document.createElement('option');
        option.setAttribute('value', value);
        option.setAttribute('id', ID);
        option.textContent = name;
        return option;
        }

        //Adds the names from the list in the dropdown as options fo every name in the list
        public void addCountryChildren(countryData) {
        const country_dropdowns = document.getElementsByClassName("country-dropdown");
        for (let i = 0; i < countryData.length; i++) {
            const data = countryData[i];
            const name = data.name;
            const value = data.code;
            const ID = data.id;
            for (const country_dropdown of country_dropdowns) {
            country_dropdown.appendChild(createOptionItem(name, value, ID));
            }
        }
        }
        //Possibly add a new function appendchild to a list of DOM elements instead of double for loop
        public void addStateChildren(names) {
        const state_dropdown = document.getElementById("state-dropdown");
        while (state_dropdown.firstChild) {
            state_dropdown.removeChild(state_dropdown.firstChild);
        }
        for (let i = 0; i < names.length; i++) {
            const data = names[i];
            const name = data.name;
            state_dropdown.appendChild(createOptionItem(name))
        }
        }

        public void addCountryEvent() {
        const bodyJSON = JSON.stringify({
            name: document.getElementById('country-input').value,
            code: document.getElementById('code-input').value
        });
        console.log(bodyJSON);
        const promise = fetch("https://xc-countries-api.herokuapp.com/api/countries/", {
            method: 'POST',
            headers: {
            'Content-Type': "application/json; charset=UTF-8"
            },
            body: bodyJSON
        });
        promise.then(res => {
            const j = res.json();
            console.log(j);
            return j;
        })
            .then(data => {
            console.log(data);
            })
        }
        public void addStateEvent() {
        const countryOptions = document.getElementById('country-dropdown-state');
        const selectedIndex = countryOptions.selectedIndex;
        const countryOption = countryOptions.children[selectedIndex];
        const countrynum = countryOption.getAttribute('id');
        const bodyJSON = JSON.stringify({
            name: document.getElementById('state-input').value,
            code: document.getElementById('statecode-input').value,
            countryId: countrynum
            //countryId: document.getElementsByTagName('option').id
        });
            }
        }
}