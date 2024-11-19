import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import OrganizationList from './components/OrganizationList';
import OrganizationCreate from './components/OrganizationCreate';
import OrganizationUpdate from './components/OrganizationUpdate';
import OrganizationRead from './components/OrganizationRead';

const App = () => {
  return (
    <Router>
      <div>
        <h1 class="text-center">Organizations Client</h1>
        <Routes>
          <Route path="/" element={<OrganizationList />} />
          <Route path="/organization/create" element={<OrganizationCreate />} />
          <Route path="/organization/update/:id" element={<OrganizationUpdate />} />
          <Route path="/organization/read/:id" element={<OrganizationRead />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;