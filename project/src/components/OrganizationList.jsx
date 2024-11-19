import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';

const OrganizationList = () => {
  const [organizations, setOrganizations] = useState([]);
  const [message, setMessage] = useState('');

  const fetchOrganizations = async () => {
    try {
      const response = await api.get('/organization');
      setOrganizations(response.data);
    } catch (error) {
      console.error('Error fetching organizations:', error);
    }
  };

  const deleteOrganization = async (id) => {
    try {
      await api.delete(`/organization/${id}`);
      setOrganizations(organizations.filter((organization) => organization.id !== id));
      setMessage('Organization deleted successfully!');
      setTimeout(() => setMessage(''), 3000);
    } catch (error) {
      console.error('Error deleting organization:', error);
      setMessage('Failed to delete organization.');
      setTimeout(() => setMessage(''), 3000);
    }
  };

  useEffect(() => {
    fetchOrganizations();
  }, []);

  return (
    <div className="container mt-5">
      <h2>Organization List</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <Link to="/organization/create" className="btn btn-success mb-3">Create New Organization</Link>
      <ul className="list-group">
        {organizations.map((organization) => (
          <li key={organization.id} className="list-group-item d-flex justify-content-between align-items-center">
            {organization.name} ({organization.address})
            <div>
              <Link to={`/organization/update/${organization.id}`} className="btn btn-warning btn-sm me-2">Update</Link>
              <button onClick={() => deleteOrganization(organization.id)} className="btn btn-danger btn-sm">Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default OrganizationList;