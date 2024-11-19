import React, { useState } from 'react';
import api from '../api/api';

function OrganizationDelete({ id, onDeleteSuccess }) {
  const [message, setMessage] = useState(''); 
  const handleDelete = async () => {
    try {
      await api.delete(`/organization/${id}`);
      onDeleteSuccess(id);
      setMessage('Organization deleted successfully!');
    } catch (error) {
      setMessage('Failed to delete organization');
    }
  };

  return (
    <div>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <button onClick={handleDelete} className="btn btn-danger btn-sm">
        Delete
      </button>
    </div>
  );
}

export default OrganizationDelete;