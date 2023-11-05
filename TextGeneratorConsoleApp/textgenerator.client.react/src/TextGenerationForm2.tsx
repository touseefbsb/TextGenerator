import React, { useState } from 'react';

interface TextGenerationForm2Props {
    onGenerateText: (template: string, dataModel: any) => void;
}

const TextGenerationForm2: React.FC<TextGenerationForm2Props> = ({ onGenerateText }) => {
    const [template, setTemplate] = useState('');
    const [name, setName] = useState('');
    const [employeeId, setEmployeeId] = useState('');
    const [experience, setExperience] = useState('');
    const [departmentName, setDepartmentName] = useState('');
    const [sectionName, setSectionName] = useState('');
    const [memberCount, setMemberCount] = useState('');

    const generateText = () => {
        const dataModel2 = {
            Name: name,
            EmployeeId: employeeId,
            Experience: experience,
            Department: {
                Name: departmentName,
                Section: {
                    Name: sectionName,
                    MemberCount: memberCount,
                },
            },
        };

        onGenerateText(template, dataModel2);
    };

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-12">
                    <div className="form-group mb-3">
                        <label className="form-label">Template:</label>
                        <input type="text" className="form-control" value={template} onChange={(e) => setTemplate(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Name:</label>
                        <input type="text" className="form-control" value={name} onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Employee ID:</label>
                        <input type="text" className="form-control" value={employeeId} onChange={(e) => setEmployeeId(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Experience:</label>
                        <input type="text" className="form-control" value={experience} onChange={(e) => setExperience(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Department Name:</label>
                        <input type="text" className="form-control" value={departmentName} onChange={(e) => setDepartmentName(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Section Name:</label>
                        <input type="text" className="form-control" value={sectionName} onChange={(e) => setSectionName(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Member Count:</label>
                        <input type="text" className="form-control" value={memberCount} onChange={(e) => setMemberCount(e.target.value)} />
                    </div>
                    <button className="btn btn-primary btn-block mt-3" onClick={generateText}>Generate Text</button>
                </div>
            </div>
        </div>
    );

};

export default TextGenerationForm2;
