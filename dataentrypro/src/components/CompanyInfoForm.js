// src/components/CompanyInfo.js
import React, { useState } from 'react';
import axios from 'axios';

const CompanyInfo = () => {
    const [companyNumber, setCompanyNumber] = useState('');
    const [companyInfo, setCompanyInfo] = useState(null);

    const handleFetchCompanyInfo = async (e) => {
        e.preventDefault();
        try {
            const token = localStorage.getItem('token');
            const response = await axios.post('/api/companyinfo', { companyNumber }, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            setCompanyInfo(response.data);
        } catch (error) {
            console.error('Error fetching company info:', error);
        }
    };

    return (
        <div>
            <h2>Fetch Company Info</h2>
            <form onSubmit={handleFetchCompanyInfo}>
                <div>
                    <label>Company Number:</label>
                    <input type="text" value={companyNumber} onChange={(e) => setCompanyNumber(e.target.value)} required />
                </div>
                <button type="submit">Fetch</button>
            </form>
            {companyInfo && (
                <div>
                    <h3>Company Info:</h3>
                    <p>Company Name: {companyInfo.companyName}</p>
                    <p>Company Number: {companyInfo.companyNumber}</p>
                    <p>Address: {companyInfo.address}</p>
                    <p>Retrieved At: {new Date(companyInfo.retrievedAt).toLocaleString()}</p>
                </div>
            )}
        </div>
    );
};

export default CompanyInfo;
