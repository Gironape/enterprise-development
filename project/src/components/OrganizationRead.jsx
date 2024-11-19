import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import api from '../api/api';

const OrganizationRead = () => {
  const { id } = useParams();
  const [organization, setOrganization] = useState(null);
  const [error, setError] = useState(null);

  const fetchOrganization = async () => {
    try {
      const response = await api.get(`/organization/${id}`);
      setOrganization(response.data);
    } catch (error) {
      console.error('Error fetching organization:', error);
      setError('Organization not found');
    }
  };

  useEffect(() => {
    fetchOrganization();
  }, [id]);

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Organization Details</h2>
      {error && (
        <div className="alert alert-danger" role="alert">
          {error}
        </div>
      )}
      {organization ? (
        <div className="card">
          <div className="card-body">
            <h5 className="card-title">Organization Information</h5>
            <p><strong>ID:</strong> {organization.id}</p>
            <p><strong>Name:</strong> {organization.name}</p>
            <p><strong>Address:</strong> {organization.address}</p>
          </div>
        </div>
      ) : error === null ? (
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      ) : null}
    </div>
  );
}

export default OrganizationRead;