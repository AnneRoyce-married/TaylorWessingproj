import React, { useState } from 'react';

const CompanyInfoForm = () => {
  const [companyName, setCompanyName] = useState('');
  const [companyData, setCompanyData] = useState(null);
  const [error, setError] = useState('');

  const handleChange = (e) => {
    setCompanyName(e.target.value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('http://localhost:5000/api/company', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ companyName }),
      });

      if (!response.ok) {
        throw new Error('Failed to fetch company data');
      }

      const data = await response.json();
      setCompanyData(data);
      setError('');
    } catch (error) {
      setError('Error fetching company data');
      console.error(error);
    }
  };

  return (
    <div className="company-info-form">
      <h2>Company Info Form</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Company Name:</label>
          <input
            type="text"
            value={companyName}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit">Get Company Info</button>
      </form>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {companyData && (
        <div>
          <h3>Company Information</h3>
          <p>Company Name: {companyData.company_name}</p>
          <p>Company Number: {companyData.company_number}</p>
          <p>Address: {companyData.registered_office_address.address_line_1}</p>
          {/* Add more fields as needed */}
        </div>
      )}
    </div>
  );
};

export default CompanyInfoForm;