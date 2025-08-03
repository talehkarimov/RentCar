export interface NavigationModel {
    title: string;
    url?: string;
    icon?: string;
    haveSubNav: boolean;
    subNavs?: NavigationModel[];
}

export const navigations: NavigationModel[] = [
    {
        title: 'Dashboard',
        url: '/',
        icon: 'bi-speedometer2',
        haveSubNav: false
    },
    {
        title: 'Test',
        icon: 'bi-users',
        haveSubNav: true,
        subNavs: [
            {
                title: 'Test',
                url: '/test',
                haveSubNav: false
            }
        ]
    }
];