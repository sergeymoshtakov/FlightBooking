import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        populateUserData();
    }, []);

    const contents = users.length === 0
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Password</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                {users.map(user =>
                    <tr key={user.userId}>
                        <td>{user.name}</td>
                        <td>{user.email}</td>
                        <td>{user.password}</td>
                        <td>{user.phone}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Users</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateUserData() {
        try {
            const response = await fetch('/users'); 
            const data = await response.json();
            setUsers(data);
        } catch (error) {
            console.error('Error fetching user data:', error);
        }
    }
}

export default App;
