$(function() {

    Morris.Area({
        element: 'morris-area-chart',
        data: [{
            period: '2018-01',
            Ocorrecia: 26,
            Reclamacao: null,
            Alerta: 26
        }, {
            period: '2018-02',
            Ocorrencia: 28,
            Reclamacao: 24,
            Alerta: 24
        }, {
            period: '2018-03',
            Ocorrencia: 92,
            Reclamacao: 19,
            Alerta: 25
        }, {
            period: '2018-04',
            Ocorrencia: 37,
            Reclamacao: 35,
            Alerta: 56
        }, {
            period: '2018-05',
            Ocorrencia: 68,
            Reclamacao: 19,
            Alerta: 22
        }, {
            period: '2018-06',
            Ocorrencia: 56,
            Reclamacao: 42,
            Alerta: 10
        }, {
            period: '2018-07',
            Ocorrencia: 48,
            Reclamacao: 37,
            Alerta: 15
        }, {
            period: '2018-08',
            Ocorrencia: 150,
            Reclamacao: 59,
            Alerta: 51
        }, {
            period: '2018-09',
            Ocorrencia: 106,
            Reclamacao: 44,
            Alerta: 20
        }, {
            period: '2018-10',
            Ocorrencia: 84,
            Reclamacao: 13,
            Alerta: 17
        }],
        xkey: 'period',
        ykeys: ['Ocorrencia', 'Reclamacao', 'Alerta'],
        labels: ['Ocorrencia', 'Reclamacao', 'Alerta'],
        pointSize: 2,
        hideHover: 'auto',
        resize: true
    });

    Morris.Donut({
        element: 'morris-donut-chart',
        data: [{
            label: "Problemas",
            value: 12
        }, {
            label: "Dificuldades",
            value: 30
        }, {
            label: "Alertas",
            value: 20
        }],
        resize: true
    });

    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: '2006',
            a: 100,
            b: 90
        }, {
            y: '2007',
            a: 75,
            b: 65
        }, {
            y: '2008',
            a: 50,
            b: 40
        }, {
            y: '2009',
            a: 75,
            b: 65
        }, {
            y: '2010',
            a: 50,
            b: 40
        }, {
            y: '2011',
            a: 75,
            b: 65
        }, {
            y: '2012',
            a: 100,
            b: 90
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Serie A', 'Serie B'],
        hideHover: 'auto',
        resize: true
    });
    
});
