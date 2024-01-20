import React, { useEffect, useState } from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import Results from '../Firebase/Results'
import { useLocation, Link } from 'react-router-dom'

function useQuery() {
    return new URLSearchParams(useLocation().search);
}

function Result() {

    let query = useQuery();
    const Email = query.get("Email");
    const ID = query.get("ID");
    const LVL = query.get("lvl");

    const [data, setData] = useState([]);

    useEffect(() => {
        const getallresult = async () => {

            const docSnap = await Results.getResults(Email);
            setData(docSnap.docs.map((doc) => (
                {
                ...doc.data(),  id: doc.id
            })))
        }

        getallresult();

        

    })

  return (
    <Container>
        <Row>
            <Col>
            <h3 className='text-center mt-2 mb-5'> <i className='fa fa-list-alt'></i> Result</h3>
            </Col>
        </Row>

        <Row>
            <Col className='table-responsive-sm'>
            <table className='table border border-black table-hover'>
                <thead className='bg-dark text-white border border-white'>
                    <tr>
                    <th className='text-center'>#</th>
                    <th className='text-center' >Topic</th>
                    <th className='text-center' >Obtained</th>
                    <th className='text-center' >Total</th>
                    <th className='text-center' >Test Date</th>
                    <th></th>
                    </tr>
                </thead>
                   
                <tbody>
                {data.map((doc, index) => {
return (

    <tr key={doc.id} >
        <td className='text-center' >{index + 1}</td>
        <td className='text-center' >{doc.Topic}</td>
        <td className='text-center' >{doc.score}</td>
        <td className='text-center' >{doc.question}</td>
        <td className='text-center' >{doc.TestDate}</td>
        <td>
        <button type='button' className='border-0 bg-transparent'><Link to={`/view-certificate?Email=${Email}&ID=${ID}&lvl=${LVL}&RID=${doc.id}`} className='h5 text-primary' ><i className='fa fa-eye'></i> </Link></button> 
        </td>
    </tr>

)
})}
                   
                </tbody>
            </table>
            </Col>
        </Row>
    </Container>
  )
}

export default Result