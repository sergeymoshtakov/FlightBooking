import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Link, Navigate } from 'react-router-dom';
import Home from './pages/Home';
import Users from './pages/Users';
import Register from './pages/Register';
import Login from './pages/Login';
import './App.css';

function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        async function checkAuth() {
            const response = await fetch('/account/isAuthenticated', {
                method: 'GET',
                credentials: 'include', 
            });

            if (response.ok) {
                setIsLoggedIn(true);
            } else {
                setIsLoggedIn(false);
            }
        }

        checkAuth();
    }, []);

    return (
        <Router>
            <div className="App">
                <header className="header">
                    <nav className="navbar">
                        <ul>
                            <li>
                                <Link to="/">Home</Link>
                            </li>
                            {isLoggedIn ? (
                                <>
                                    <li>
                                        <Link to="/users">Users</Link>
                                    </li>
                                </>
                            ) : (
                                <>
                                    <li>
                                        <Link to="/register">Register</Link>
                                    </li>
                                    <li>
                                        <Link to="/login">Login</Link>
                                    </li>
                                </>
                            )}
                        </ul>
                    </nav>
                </header>

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/users" element={isLoggedIn ? <Users /> : <Navigate to="/login" />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/login" element={<Login />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
