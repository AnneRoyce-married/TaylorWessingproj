// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import CompanyInfo from './components/CompanyInfo';

const App = () => {
    return (
        <Router>
            <div>
                <h1>Simple Web App</h1>
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/companyinfo" element={<CompanyInfo />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
