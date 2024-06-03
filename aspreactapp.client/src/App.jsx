import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [persons, setPersons] = useState();

    useEffect(() => {
        personData();
    }, []);

    const content = persons === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Nom</th>
                    <th>Prenom</th>
                    <th>Age</th>
                    <th>Numero</th>
                    <th>Mot de passe</th>
                </tr>
            </thead>
            <tbody>
                {persons.map(person =>
                    <tr key={person.personID}>
                        <td>{person.nom}</td>
                        <td>{person.prenom}</td>
                        <td>{person.age}</td>
                        <td>{person.numero}</td>
                        <td>{person.password}</td>
                    </tr>
                )}
            </tbody>
        </table>;


    const contents_person = persons === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Nom</th>
                    <th>Prénom</th>
                    <th>Age</th>
                    <th>Numéro</th>
                </tr>
            </thead>
            <tbody>
                {persons.map(person =>
                    <tr key={person.nom}>
                        <td>{person.nom}</td>
                        <td>{person.prenom}</td>
                        <td>{person.age}</td>
                        <td>{person.numero}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Mes Test d'appels d'api</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {content}
        </div>
    );

    async function personData() {
        const response = await fetch('api/person');
        const data = await response.json();
        setPersons(data);
    }

}

export default App;